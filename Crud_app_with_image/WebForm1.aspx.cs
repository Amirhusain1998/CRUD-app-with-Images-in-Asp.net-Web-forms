using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;
using Image = System.Web.UI.WebControls.Image;

namespace Crud_app_with_image
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGrid();
            }
        }
         void ResetControl()
        {
            IdTextBox.Text=NameTextBox.Text=AgeTextBox.Text=SalaryTextBox.Text=" ";
            Genderddl.ClearSelection();
            Desigddl.ClearSelection();
            Label1.Visible = false;
            Getimg.Visible= false;
            GridView1.SelectedIndex = -1;

        }
        void BindGrid()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Employee1";
            SqlDataAdapter sda=new SqlDataAdapter(query, con);
            DataTable td=new DataTable();
            sda.Fill(td);
            GridView1.DataSource = td;
            GridView1.DataBind();
        }

        protected void INSERTBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string filepath = Server.MapPath("images/");
            string fileName=Path.GetFileName(FileUpload1.FileName);
            string extension=Path.GetExtension(fileName);
            HttpPostedFile postedfile = FileUpload1.PostedFile;
            int size = postedfile.ContentLength;
            if(FileUpload1.HasFile==true)
            {
                if(extension.ToLower()==".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if(size<=1000000)
                    {
                        string query2 = "select *from Employee1 where id=@id";
                        SqlCommand cmd2= new SqlCommand(query2, con);
                        cmd2.Parameters.AddWithValue("@id", IdTextBox.Text);
                        con.Open();
                        SqlDataReader dr= cmd2.ExecuteReader();
                        if(dr.HasRows==true)
                        {
                            Response.Write("<script>alert('Id already exsist')</script>");
                            con.Close();
                        }
                        else
                        {
                            con.Close();
                            FileUpload1.SaveAs(filepath + fileName);
                            string path2 = "images/" + fileName;
                            string query = "insert into Employee1 values(@id,@name,@age,@gender,@desig,@salary,@img)";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@id", IdTextBox.Text);
                            cmd.Parameters.AddWithValue("@name", NameTextBox.Text);
                            cmd.Parameters.AddWithValue("@age", AgeTextBox.Text);
                            cmd.Parameters.AddWithValue("@gender", Genderddl.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@desig", Desigddl.SelectedItem.Value);
                            cmd.Parameters.AddWithValue("@salary", SalaryTextBox.Text);
                            cmd.Parameters.AddWithValue("@img", path2);
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            int a = cmd.ExecuteNonQuery();
                            if (a > 0)
                            {
                                Response.Write("<script>alert('Data Inserted')</script>");
                                
                                BindGrid();
                                
                                ResetControl();
                                Label1.Visible = true;

                            }
                            else
                            {
                                Response.Write("<script>alert('Data not Inserted')</script>");

                            }
                            con.Close();
                        }

                        

                    }
                    else
                    {
                        Label1.Text = "image length should be 1 MB";
                        Label1.Visible = true;
                        Label1.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Label1.Text = "image format not supported";
                    Label1.Visible = true;
                    Label1.ForeColor = Color.Red;
                }

            }
            else
            {
                Label1.Text = "please upload image";
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Label lblid =(Label) row.FindControl("Labelid");
            Label lblname = (Label)row.FindControl("Labelname");
            Label lblage = (Label)row.FindControl("Labelage");
            Label lblgender = (Label)row.FindControl("Labelgender");
            Label lbldes = (Label)row.FindControl("Labeldesig");
            Label lblsal = (Label)row.FindControl("Labelsalary");
            Image img = (Image)row.FindControl("Image1");

            IdTextBox.Text = lblid.Text;
            NameTextBox.Text = lblname.Text;
            AgeTextBox.Text = lblage.Text;
            Genderddl.Text = lblgender.Text;
            Desigddl.Text = lbldes.Text;
            SalaryTextBox.Text = lblsal.Text;
            Getimg.ImageUrl = img.ImageUrl;
            Getimg.Visible= true;


        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string filepath = Server.MapPath("images/");
            string fileName = Path.GetFileName(FileUpload1.FileName);
            string extension = Path.GetExtension(fileName);
            HttpPostedFile postedfile = FileUpload1.PostedFile;
            int size = postedfile.ContentLength;

            string UpdatePath = "images/";
            if (FileUpload1.HasFile == true)
            {
                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (size <= 1000000)
                    {
                        UpdatePath = UpdatePath + fileName;
                        FileUpload1.SaveAs(Server.MapPath(UpdatePath));
                        string query = "update Employee1 set name=@name,age=@age,gender=@gender,designation=@desig,salar=@salary,img_path=@img where id=@id";
                        SqlCommand cmd=new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id",IdTextBox.Text);
                        cmd.Parameters.AddWithValue("@name", NameTextBox.Text);
                        cmd.Parameters.AddWithValue("@age",AgeTextBox.Text);
                        cmd.Parameters.AddWithValue("@gender",Genderddl.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@desig",Desigddl.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@salary",SalaryTextBox.Text);
                        cmd.Parameters.AddWithValue("@img", UpdatePath);
                       con.Open();
                       int a= cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            Response.Write("<script>alert('Data Updated')</script>");

                            BindGrid();

                            ResetControl();
                            Label1.Visible = false;
                            Getimg.Visible = false;
                        }
                        else
                        {
                            Response.Write("<script>alert('Data not Updated')</script>");

                        }
                        con.Close();
                    }
                    else
                    {
                        Label1.Text = "image length should be 1 MB";
                        Label1.Visible = true;
                        Label1.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Label1.Text = "image format not supported";
                    Label1.Visible = true;
                    Label1.ForeColor = Color.Red;
                }

            }
            else
            {
                UpdatePath = Getimg.ImageUrl.ToString();
                string query = "update Employee1 set name=@name,age=@age,gender=@gender,designation=@desig,salar=@salary,img_path=@img where id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", IdTextBox.Text);
                cmd.Parameters.AddWithValue("@name", NameTextBox.Text);
                cmd.Parameters.AddWithValue("@age", AgeTextBox.Text);
                cmd.Parameters.AddWithValue("@gender", Genderddl.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@desig", Desigddl.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@salary", SalaryTextBox.Text);
                cmd.Parameters.AddWithValue("@img", UpdatePath);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Response.Write("<script>alert('Data Updated')</script>");

                    BindGrid();

                    ResetControl();
                    Label1.Visible = false;
                    Getimg.Visible = false;
                    string deletepath = Server.MapPath(Getimg.ImageUrl).ToString();
                    if (File.Exists(deletepath) == true)
                    {
                        File.Delete(deletepath);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Data not Updated')</script>");

                }
                con.Close();
            }
        }

        protected void DeletrButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "delete from Employee1 where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", IdTextBox.Text);
            
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                Response.Write("<script>alert('Data Deleted')</script>");

                BindGrid();

                ResetControl();
                Label1.Visible = false;
                Getimg.Visible = false;
                string deletepath = Server.MapPath(Getimg.ImageUrl).ToString();
                if(File.Exists(deletepath)==true)
                {
                    File.Delete(deletepath);
                }
            }
            else
            {
                Response.Write("<script>alert('Data not Deleted')</script>");

            }
            con.Close();

        }
    }
}
