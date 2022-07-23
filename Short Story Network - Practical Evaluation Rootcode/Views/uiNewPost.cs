using Short_Story_Network___Practical_Evaluation_Rootcode.Controlers;
using Short_Story_Network___Practical_Evaluation_Rootcode.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_Story_Network___Practical_Evaluation_Rootcode.Views
{
    public partial class uiNewPost : Form
    {
        public int postID = 0;
        public int userID = 0;
        private LoggedUserDetails _loggedUserDetailsObj;
        private bool _overrideAccess = false;
        private int _userPostID = 0;
        private bool _hasImage = false;
        public uiNewPost(LoggedUserDetails loggedUserDetailsObj, bool overrideAccess = false, int userPostID = 0)
        {
            InitializeComponent();
            _loggedUserDetailsObj = loggedUserDetailsObj;
            _overrideAccess = overrideAccess;
            _userPostID = userPostID;
            UI_Handler();
        }

        clsPost clsPostObj = new();

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                Word_Count_Handler();
                if (wordsCount > 500)
                {
                    MessageBox.Show("Word Count should be less than 500. Current count is " + wordsCount.ToString());
                }
                else
                {
                    Post postObj = new()
                    {
                        Post1 = postText.Text,
                        UserId = _loggedUserDetailsObj.userID,
                        hasImage = _hasImage
                    };
                    PicBox_Image_Validate(postObj);

                    if (postID > 0)
                    {
                        postObj.PostId = postID;
                    }
                    clsPostObj.Save_Date(postObj);

                    Count_Handler();
                    StatVowel statVowelObj = new()
                    {
                        Date = DateTime.Now,
                        SingleVowelCount = singleVowel.Count,
                        PairVowelCount = doubleVowel.Count,
                        TotalWordCount = wordsCount,
                        Post = postText.Text
                    };

                    if (postID > 0)
                    {
                        postObj.PostId = postID;
                    }
                    clsPostObj.Save_Word_Date(statVowelObj);

                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void PicBox_Image_Validate(Post postObj)
        {
            try
            {
                try
                {
                    if (ItemImage != null && ItemImage.GetType() == typeof(byte[]))
                    {

                        postObj.Image = ItemImage;

                    }
                    else if (pictureBox1.Image != null && pictureBox1.Image.GetType() == typeof(Bitmap))
                    {
                        postObj.Image = ImageToByteArray((Bitmap)pictureBox1.Image);
                    }
                    else if (pictureBox1.Image == null)
                    {
                        Byte[] array = new Byte[64];
                        Array.Clear(array, 0, array.Length);
                        postObj.Image = array;
                    }
                    else
                    {
                        postObj.Image = ImageToByteArray((Bitmap)pictureBox1.Image);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Image Validation error");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Load_Post(int getPostID)
        {
            try
            {
                clsPost clsPostObj = new();
                var writerList = (List<Post>)clsPostObj.Get_Post(getPostID).ResultObject;
                if (writerList.Count > 0)
                {
                    postText.Text = writerList[0].Post1.ToString();
                    if (writerList[0].hasImage)
                    {
                        pictureBox1.Image = ByteToImage(writerList[0].Image);
                        panel2.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void addComment_Click(object sender, EventArgs e)
        {
            try
            {
                uiComments commentsObj = new(_loggedUserDetailsObj, false)
                {
                    userID = _loggedUserDetailsObj.userID,
                    postID = postID
                };
                commentsObj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void seeComments_Click(object sender, EventArgs e)
        {
            try
            {
                uiCommentsList commentsListObj = new(_loggedUserDetailsObj, _overrideAccess);
                commentsListObj.Fill_Data(postID);
                commentsListObj.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UI_Handler()
        {
            try
            {
                clsUserAccessHandler clsUserAccessHandler = new clsUserAccessHandler();
                addComment.Enabled = _userPostID != _loggedUserDetailsObj.userID && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.AddComment);
                seeComments.Enabled = _overrideAccess != true && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.SeeComments);
                Confirm.Enabled = _overrideAccess != true && _userPostID == _loggedUserDetailsObj.userID && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.CreatePost)
                    && clsUserAccessHandler.Access_Handler(_loggedUserDetailsObj.UserAccessType, UserAccessTypes.EditPost);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Image Handlers
        public byte[] ItemImage = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = true;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "";

                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;

                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "Image files", "*.JPEG;*.JPG;*.JFIF;*.JPEG2000;*.Exif;*.TIFF;*.GIF;*.*.BMP;*.PNG;*.PPM; .PGM; .PBM; *.PNM;*.WebP;*.HEIF;*.BAT;*.BPG;");

                dlg.DefaultExt = ".jpg"; // Default file extension 

                // Show open file dialog box 
                var result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _hasImage = true;
                    string fileName = dlg.FileName;

                    if (fileName == "" || fileName == null)
                    {
                    }
                    else
                    {
                        if (ValidFile(dlg.FileName, 102400))
                        {
                            pictureBox1.Image = Image.FromFile(fileName);
                            ItemImage = null;
                        }
                        else
                        {
                            pictureBox1.Image = Image.FromStream(CompreddedImageToByteArray(Image.FromFile(fileName), 2));
                            //Image img = (Image)uPicBox.Image;
                            ItemImage = null;
                            //MessageBox.Show("Please select an image less than 1MB");
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private byte[] ImageHandler(string fileName)
        {
            byte[] ImageData = System.IO.File.ReadAllBytes(fileName);
            return ImageData;


        }

        public byte[] ImageToByteArray(System.Drawing.Image image)
        {
            ImageFormat format = image.RawFormat;
            ImageCodecInfo codec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == format.Guid);
            string mimeType = codec.MimeType;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private bool ValidFile(string filename, long limitInBytes)
        {
            var fileSizeInBytes = new FileInfo(filename).Length;
            if (fileSizeInBytes > limitInBytes)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public MemoryStream CompreddedImageToByteArray(Image img, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

            // Encoder parameter for image quality 
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            // JPEG image codec 
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            var ms = new MemoryStream();
            img.Save(ms, jpegCodec, encoderParams);
            return ms;

        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats 
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec 
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            Bitmap bm = null;
            if (blob.Length > 64)
            {
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                bm = new Bitmap(mStream, false);
                mStream.Dispose();
            }
            return bm;
        }
        #endregion
        #region Image Handlers
        private void Word_Count_Handler()
        {
            try
            {
                var testValue = postText.Text;
                int wordCount = 0, index = 0;
                List<string> words = new List<string>();

                // skip whitespace until first word
                while (index < testValue.Length && char.IsWhiteSpace(testValue[index]))
                    index++;

                while (index < testValue.Length)
                {
                    // check if current char is part of a word
                    while (index < testValue.Length && !char.IsWhiteSpace(testValue[index]))
                        index++;
                    wordCount++;

                    // skip whitespace until next word
                    while (index < testValue.Length && char.IsWhiteSpace(testValue[index]))
                        index++;
                }
                wordsCount = wordCount;
            }
            catch (Exception)
            {

            }
        }
        private List<string> singleVowel;
        private List<string> doubleVowel;
        private int wordsCount;
        private int Count_Handler()
        {
            try
            {
                var testValue = postText.Text;
                string vowels = "aeiou";
                List<string> words = testValue.Split(' ').ToList();
                var vowelWords = words.Where(word => word.Any(c => vowels.Contains(c)))
                        .ToList();

                doubleVowel = vowelWords.Where(word => word.Count(c => vowels.Contains(c)) < 2)
                     .ToList();

                singleVowel = vowelWords.Where(word => word.Count(c => vowels.Contains(c)) < 3)
                     .ToList();
                return 1;
            }
            catch (Exception)
            {

                return 1;
            }
        }
        #endregion
    }
}