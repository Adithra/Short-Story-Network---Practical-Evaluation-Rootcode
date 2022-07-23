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
            FileStream fs;
            BinaryReader br;
            string FileName = button1.Tag.ToString();
            byte[] ImageData;
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            Post postObj = new()
            {
                Post1 = postText.Text,
                UserId = _loggedUserDetailsObj.userID
            };
            if (postID > 0)
            {
                postObj.PostId = postID;
            }
            clsPostObj.Save_Date(postObj);
            this.Close();
        }

        public void Load_Post(int getPostID) {
            try
            {
                clsPost clsPostObj = new();
                var writerList = (List<Post>)clsPostObj.Get_Post(getPostID).ResultObject;
                if (writerList.Count >0)
                {
                    postText.Text = writerList[0].Post1.ToString();
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
        public byte[] ItemImage = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "";

                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;

                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "Image files", "*.JPEG;*.JPG;*.JFIF;*.JPEG2000;*.Exif;*.TIFF;*.GIF;*.*.BMP;*.PNG;*.PPM; .PGM; .PBM; *.PNM;*.WebP;*.HEIF;*.BAT;*.BPG;");

                dlg.DefaultExt = ".jpg"; // Default file extension 

                // Show open file dialog box 
                dlg.ShowDialog();

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
                        pictureBox1.Image = Image.FromStream(CompreddedImageToByteArray(Image.FromFile(fileName), 20));
                        //Image img = (Image)uPicBox.Image;
                        ItemImage = null;
                        //img.Save(@"C:\Users\SPIL\OneDrive\Documents\Web developments\Downloads\new.jpeg");
                        //MessageBox.Show("Please select an image less than 1MB");
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

        /// <summary> 
        /// Saves an image as a jpeg image, with the given quality 
        /// </summary> 
        /// <param name="path"> Path to which the image would be saved. </param> 
        /// <param name="quality"> An integer from 0 to 100, with 100 being the highest quality. </param> 
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

        /// <summary> 
        /// Returns the image codec with the given mime type 
        /// </summary> 
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

    }
}
