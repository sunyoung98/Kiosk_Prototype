using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HAI_KIOSK
{

    public partial class M_Form : Form
    {
        //Dictionary<string, float> HuDict = new Dictionary<string, float>();
        List<Dictionary<string, int>> basic_bag = new List<Dictionary<string, int>>();
        Dictionary<string, int> basic_menu = new Dictionary<string, int>();
        Dictionary<string, int> h_basic_menu = new Dictionary<string, int>();
        NoiseMonitor NM = new NoiseMonitor();
        int set_c_count = 0;
        int set_d_count = 0;
        int payment_ts_count = 0;
        int Cur_Slevel = 100;
        int scn_type = 0;

        List<string> h_menu = new List<string>(){"새우버거",
                                "클래식치즈버거",
                                "더블패티버거",
                                "대왕치킨버거",
                                "광운새우버거",
                                "불고기버거",
                                "광운버거",
                                "트리플치즈버거",};
        List<string> c_menu = new List<string>(){"크림치즈볼",
                                    "웨지포테이토",
                                    "지파이(매콤)",
                                    "지파이(고소)",
                                    "감자튀김",
                                    "롱치즈스틱",
                                    "미니치킨너겟",
                                    "양념감자",
                                    "포테이토",
                                    "치즈스틱",
                                    "딸기선데이",
                                    "콘샐러드",};
        List<string> d_menu = new List<string>(){"콜라",
                                    "제로콜라",
                                    "사이다",
                                    "레몬에이드",
                                    "딸기쉐이크",
                                    "초코쉐이크",
                                    "밀크쉐이크",
                                    "아이스티",
                                    "아메리카노",
                                    "카페라떼",
                                    "우유",
                                    "핫초코",};

        char menuc = 'h';
        int h_index = -1;
        public M_Form()
        {
            InitializeComponent();
            this.Size = new Size(630, 1157);
            main_panel.Dock = DockStyle.Fill;
            pictureBox1.Dock = DockStyle.Fill;
            orderfin_panel.Dock = DockStyle.Fill;
            payment_panel.Dock = DockStyle.Fill;
            p_tlp_panel.Controls.Add(h_tlp);
            p_tlp_panel.Controls.Add(c_tlp);
            p_tlp_panel.Controls.Add(d_tlp);
            h_tlp.Dock = DockStyle.Fill;
            c_tlp.Dock = DockStyle.Fill;
            d_tlp.Dock = DockStyle.Fill;
            basic_menu["m_key"] = 0;
            basic_menu["h_key"] = 0;
            basic_menu["c_key"] = 0;
            basic_menu["d_key"] = 0;
            basic_menu["count"] = 0;
            h_basic_menu = new Dictionary<string, int>(basic_menu);


            NM.SendSlevel += new NoiseMonitor.NM_EventHandler_Slevel(get_Slevel);
            NM.ModifyScnType += new NoiseMonitor.NM_EventHandler_SCNOption(Modify_SCN);
            NM.Show();

            orderfin_panel.Size = new Size(630, 1120);

            //KPlayer.URL = @"./audio_7_주문번호를_확인해주세요_.wav";


            ord_m_show_panel.Controls.Add(set_tpl_c);
            ord_m_show_panel.Controls.Add(set_tpl_d);
            set_tpl_c.Dock = DockStyle.Fill;
            set_tpl_d.Dock = DockStyle.Fill;
        }

        public void scn_sound_out(int snnum)
        {
            if (scn_type == 0)
            {
                update_SLevel();
                switch (snnum)
                {
                    case 1:
                        KPlayer.URL = @"./scenario1/audio_0.wav";
                        break;
                    // 제품선택
                    case 3:
                        KPlayer.URL = @"./scenario1/audio_2.wav";
                        break;
                    // 제품 선택후 선택완료 눌러주세요
                    case 6:
                        KPlayer.URL = @"./scenario1/audio_5.wav";
                        break;
                    //포장하시겠?
                    case 8:
                        KPlayer.URL = @"./scenario1/audio_7.wav";
                        break;
                    // 주문번호 확인 부탁 드립니다.
                    case 12:
                        KPlayer.URL = @"./scenario1/audio_8.wav";
                        break;
                    // 단품또는 세트를 선택해 주세요
                    default:
                        break;
                }
            }
            else
            {
                update_SLevel();
                switch (snnum)
                {
                    case 1:
                        KPlayer.URL = @"./scenario1/audio_0.wav";
                        break;
                    // 제품선택
                    case 2:
                        KPlayer.URL = @"./scenario1/audio_1.wav";
                        break;
                    // 불고기 버거 세트 선택 _#
                    case 3:
                        KPlayer.URL = @"./scenario1/audio_12.wav";
                        break;
                    // 제품 선택후 선택완료 눌러주세요
                    case 4:
                        KPlayer.URL = @"./scenario1/audio_3.wav";
                        break;
                    // 세트 -> 디저트 선택 _#
                    case 5:
                        KPlayer.URL = @"./scenario1/audio_4.wav";
                        break;
                    // 세트-> 음료선택 _ #
                    case 6:
                        KPlayer.URL = @"./scenario1/audio_5.wav";
                        break;
                    //포장하시겠?
                    case 7:
                        KPlayer.URL = @"./scenario1/audio_6.wav";
                        break;
                    // 매장식사를 선택 _ #
                    case 8:
                        KPlayer.URL = @"./scenario1/audio_7.wav";
                        break;
                    // 주문번호 확인 부탁 드립니다.
                    case 9:
                        KPlayer.URL = @"./scenario2/audio_1.wav";
                        break;
                    // 감자튀김 _#
                    case 10:
                        KPlayer.URL = @"./scenario2/audio_2.wav";
                        break;
                    // 딸기쉐이크_#
                    case 11:
                        KPlayer.URL = @"./scenario2/audio_4.wav";
                        break;
                    // 포장을 선택함_#
                    case 12:
                        KPlayer.URL = @"./scenario1/audio_11.wav";
                        break;
                    // 불고기 버거 선택, 단품 세트 선택해주세요#
                    //case 13:
                    //    KPlayer.URL = @"./scenario1/audio_9.wav";
                    //    break;
                    //// 불고기버거를 선택하셨습니다._#
                    default:
                        break;
                }
            }
        }

        public void update_SLevel()
        {
            KPlayer.settings.volume = Cur_Slevel;
        }

        public void get_Slevel(int Slevel)
        {
            Cur_Slevel = Slevel;
            //label5.Text = Cur_Slevel.ToString();
        }


        public void Modify_SCN(int stype)
        {
            scn_type = stype;
        }
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 실험시작 정상 작동 메소드

        public void main2order()
        {
            main_panel.Visible = false;
            order_panel.Visible = true;
            btn_h.BackColor = Color.White;
            order_panel.Dock = DockStyle.Fill;
            h_tlp.Visible = true;
            scn_sound_out(1);
        }


        public void order2main()
        {
            main_panel.Visible = true;
            order_panel.Visible = false;
            btn_h.BackColor = Color.White;
            order_panel.Dock = DockStyle.Fill;
            foreach (Control item in panel2.Controls)
            {
                item.BackColor = Color.Pink;
            }

        }




        private void Hsize_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            main2order();
        }

        private void main_panel_MouseDown(object sender, MouseEventArgs e)
        {
            main2order();
        }


        // intro 2 order page

        private void btn_Click(object sender, EventArgs e)
        {
            h_tlp.Visible = false;
            c_tlp.Visible = false;
            d_tlp.Visible = false;
            char[] delimi = { ' ', };
            char fword = sender.ToString().Split(delimi)[2][0];
            foreach (Control item in panel2.Controls)
            {
                item.BackColor = Color.Pink;
            }
            switch (fword)
            {
                case '햄':
                    btn_h.BackColor = Color.White;
                    h_tlp.Visible = true;
                    menuc = 'h';
                    break;
                case '디':
                    btn_c.BackColor = Color.White;
                    c_tlp.Visible = true;
                    menuc = 'c';
                    break;
                case '음':
                    btn_d.BackColor = Color.White;
                    d_tlp.Visible = true;
                    menuc = 'd';
                    break;
                default:
                    break;
            }

        }

        private void pb_cancel_Click(object sender, EventArgs e)
        {
            basic_bag = new List<Dictionary<string, int>>();
            Show_Counts.Controls.Clear();
            order2main();
            order_allprice_lbl.Text = "0";
            order_count_lbl.Text = "0";
        }
        private void pb_payment_Click(object sender, EventArgs e)
        {
            if (basic_bag.Count == 0)
            {
                MessageBox.Show("Choose least one menu pls !!");
                return;
            }
            scn_sound_out(6);
            //포장하시겠습니까?
            order_panel.Visible = false;
            payment_panel.Visible = true;

            foreach (PictureBox item in payment_ts_panel.Controls)
            {
                item.BorderStyle = BorderStyle.None;
            }
            payment_ts_lbl.Text = " 포장/매장 여부 선택해주세요";

            payment_lst_panel.Controls.Clear();
            int all_price = 0;
            string m_text = "";
            foreach (Dictionary<string, int> item in basic_bag)
            {
                int set_c = 0;
                int price = 0;
                if (item["m_key"] >= 10000)
                {
                    if (item["m_key"] % 10000 != 0)
                    {
                        price = 6700;
                        m_text = h_menu[item["h_key"] - 1] + " 세트";
                        set_c += 1;
                    }
                    else
                    {
                        price = 4900;
                        m_text = h_menu[item["h_key"] - 1];
                    }
                }
                else if (item["m_key"] >= 100)
                {
                    price = 2000;
                    m_text = c_menu[item["c_key"] - 1];
                }
                else
                {
                    price = 1000;
                    m_text = d_menu[item["d_key"] - 1];
                }

                price *= item["count"];
                //MessageBox.Show(price.ToString());
                all_price += price;

                if (set_c == 1)
                {

                    payment_row temp_prow_d = new payment_row("-" + d_menu[item["d_key"] - 1], item["count"].ToString(), "0");
                    payment_row temp_prow_c = new payment_row("-" + c_menu[item["c_key"] - 1], item["count"].ToString(), "0");
                    payment_row temp_prow_h = new payment_row(m_text, item["count"].ToString(), price.ToString());

                    temp_prow_d.Dock = DockStyle.Top;
                    temp_prow_c.Dock = DockStyle.Top;
                    temp_prow_h.Dock = DockStyle.Top;


                    payment_lst_panel.Controls.Add(temp_prow_d);
                    payment_lst_panel.Controls.Add(temp_prow_c);
                    payment_lst_panel.Controls.Add(temp_prow_h);


                }
                else
                {
                    payment_row temp_prow = new payment_row(m_text, item["count"].ToString(), price.ToString());
                    temp_prow.Dock = DockStyle.Top;
                    payment_lst_panel.Controls.Add(temp_prow);
                }
            }
            payment_totalprice_lbl.Text = all_price.ToString();

        }

        private void M_Form_Load(object sender, EventArgs e)
        {
            List<PictureBox> hpic_lst = new List<PictureBox>();
            List<PictureBox> dpic_lst = new List<PictureBox>();
            List<PictureBox> cpic_lst = new List<PictureBox>();
            for (int i = 0; i < h_imglst.Images.Count; i++)
            {
                PictureBox tpb = new PictureBox();
                tpb.Name = "hbtn_" + i.ToString();
                tpb.Dock = DockStyle.Fill;
                tpb.Image = h_imglst.Images[i];
                tpb.SizeMode = PictureBoxSizeMode.StretchImage;
                tpb.Click += new System.EventHandler(pbclick);
                hpic_lst.Add(tpb);
                h_tlp.Controls.Add(tpb, i % 2, i / 2);
            }
            for (int i = 0; i < h_imglst.Images.Count; i++)
            {
                PictureBox tpb = new PictureBox();
                tpb.Name = "cbtn_" + i.ToString();
                tpb.Dock = DockStyle.Fill;
                tpb.Image = c_imglst.Images[i];
                tpb.SizeMode = PictureBoxSizeMode.StretchImage;
                tpb.Click += new System.EventHandler(pbclick);
                dpic_lst.Add(tpb);
                c_tlp.Controls.Add(tpb, i % 2, i / 2);
            }
            for (int i = 0; i < h_imglst.Images.Count; i++)
            {
                PictureBox tpb = new PictureBox();
                tpb.Name = "dbtn_" + i.ToString();
                tpb.Dock = DockStyle.Fill;
                tpb.Image = d_imglst.Images[i];
                tpb.SizeMode = PictureBoxSizeMode.StretchImage;
                tpb.Click += new System.EventHandler(pbclick);
                hpic_lst.Add(tpb);
                d_tlp.Controls.Add(tpb, i % 2, i / 2);
            }

            for (int i = 0; i < set_c_imglst.Images.Count; i++)
            {
                PictureBox tpb = new PictureBox();
                tpb.Name = "scbtn_" + i.ToString();
                tpb.Dock = DockStyle.Fill;
                tpb.Image = set_c_imglst.Images[i];
                tpb.SizeMode = PictureBoxSizeMode.StretchImage;
                tpb.Click += new System.EventHandler(set_pbclick);
                set_tpl_c.Controls.Add(tpb, i % 3, i / 3);
            }

            for (int i = 0; i < set_d_imglst.Images.Count; i++)
            {
                PictureBox tpb = new PictureBox();
                tpb.Name = "sdbtn_" + i.ToString();
                tpb.Dock = DockStyle.Fill;
                tpb.Image = set_d_imglst.Images[i];
                tpb.SizeMode = PictureBoxSizeMode.StretchImage;
                tpb.Click += new System.EventHandler(set_pbclick);
                set_tpl_d.Controls.Add(tpb, i % 3, i / 3);
            }
        }
        // btn change & pbl type change
        // 실험번호에 숫자만 입력 가능 이벤트 핸들러

        private void set_pbclick(object sender, EventArgs e)
        {
            char[] delimi = { '_', };
            PictureBox temp = new PictureBox();
            temp = (PictureBox)sender;
            int index = Int32.Parse(temp.Name.Split(delimi)[1]);
            //MessageBox.Show(temp.Name.Split(delimi)[1]);
            if (temp.Name.Split(delimi)[0] == "scbtn")
            {
                scn_sound_out(4);
                foreach (PictureBox item in set_tpl_c.Controls)
                {
                    item.BorderStyle = BorderStyle.None;
                }
                PictureBox bordertem = new PictureBox();
                bordertem = (PictureBox)set_tpl_c.Controls[index];
                bordertem.BorderStyle = BorderStyle.Fixed3D;
                change_ord_view(2);
                //h_basic_menu["c_key"] = index;
            }
            else
            {
                scn_sound_out(5);
                foreach (PictureBox item in set_tpl_d.Controls)
                {
                    item.BorderStyle = BorderStyle.None;
                }
                PictureBox bordertem = new PictureBox();
                bordertem = (PictureBox)set_tpl_d.Controls[index];
                bordertem.BorderStyle = BorderStyle.Fixed3D;
                change_ord_view(1);
                //h_basic_menu["d_key"] = index;
            }
            //MessageBox.Show("You Choose " + temp.Name);
        }

        public void change_ord_view(int type_of_menu)
        {
            set_tpl_c.Visible = false;
            set_tpl_d.Visible = false;

            foreach (Control item in set_d_btn.Parent.Controls)
            {
                item.BackColor = Color.Pink;
            }
            switch (type_of_menu)
            {
                case 1:
                    label2.Text = "세트디저트 1개를 선택해 주세요";
                    set_c_btn.BackColor = Color.White;
                    set_tpl_c.Visible = true;
                    if (set_c_count == 0)
                        set_c_count += 1;
                    break;
                case 2:
                    label2.Text = "세트드링크 1개를 선택해 주세요";
                    set_d_btn.BackColor = Color.White;
                    set_tpl_d.Visible = true;
                    if (set_d_count == 0)
                        set_d_count += 1;
                    break;
                default:
                    break;
            }
            ch_num_lbl.Text = (set_d_count + set_d_count).ToString();
            left_num_lbl.Text = (2 - set_d_count - set_c_count).ToString();
        }

        private void pbclick(object sender, EventArgs e)
        {
            char[] delimi = { '_', };
            PictureBox temp = new PictureBox();
            temp = (PictureBox)sender;
            int index = Int32.Parse(temp.Name.Split(delimi)[1]);
            Dictionary<string, int> t_menu = new Dictionary<string, int>(basic_menu);

            switch (temp.Name.Split(delimi)[0])
            {
                case "hbtn":
                    t_menu["h_key"] = index + 1;
                    t_menu["count"] = 1;
                    t_menu["m_key"] = t_menu["h_key"] * 10000 + t_menu["c_key"] * 100 + t_menu["d_key"];
                    h_basic_menu = t_menu;
                    h_click();
                    break;
                case "cbtn":
                    scn_sound_out(9);
                    t_menu["m_key"] = 0;
                    t_menu["c_key"] = index + 1;
                    t_menu["count"] = 1;
                    t_menu["m_key"] = t_menu["h_key"] * 10000 + t_menu["c_key"] * 100 + t_menu["d_key"];
                    overlap_check(t_menu);
                    break;
                case "dbtn":
                    scn_sound_out(10);
                    t_menu["m_key"] = 0;
                    t_menu["d_key"] = index + 1;
                    t_menu["count"] = 1;
                    t_menu["m_key"] = t_menu["h_key"] * 10000 + t_menu["c_key"] * 100 + t_menu["d_key"];
                    overlap_check(t_menu);
                    break;
                default:
                    break;
            }
        }
        // click menu picture box



        private void h_mousedown(object sender, EventArgs e)
        {
            char[] delimi = { '_', };
            PictureBox temp = new PictureBox();
            temp = (PictureBox)sender;

            switch (temp.Name.Split(delimi)[1])
            {
                case ("obug"):
                    overlap_check(h_basic_menu);
                    ord_cho_panel.Visible = false;
                    break;
                case ("set"):
                    scn_sound_out(3);
                    ord_cho_panel.Visible = false;
                    h_click_2();
                    break;
                default:
                    break;
            }

        }
        // click onlybug || set


        public void overlap_check(Dictionary<string, int> s_menu)
        {

            int up_count = 0;
            foreach (Dictionary<string, int> item in basic_bag)
            {
                if (s_menu["m_key"] == item["m_key"])
                {
                    item["count"] += 1;
                    up_count += 1;
                    break;
                }
            }
            if (up_count == 0)
                basic_bag.Add(s_menu);
            update_bag();

        }
        //overlap check

        public void update_bag()
        {
            Show_Counts.Controls.Clear();
            int r_ind = 0;
            int all_count = 0;
            int all_price = 0;
            string m_text = "";
            foreach (Dictionary<string, int> item in basic_bag)
            {
                all_count += item["count"];
                int price = 0;
                if (item["m_key"] >= 10000)
                {
                    if (item["m_key"] % 10000 != 0)
                    {
                        price = 6700;
                        m_text = h_menu[item["h_key"] - 1] + " 세트";
                    }
                    else
                    {
                        price = 4900;
                        m_text = h_menu[item["h_key"] - 1];
                    }
                }
                else if (item["m_key"] >= 100)
                {
                    price = 2000;
                    m_text = c_menu[item["c_key"] - 1];
                }
                else
                {
                    price = 1000;
                    m_text = d_menu[item["d_key"] - 1];
                }

                price *= item["count"];
                all_price += price;
                menu_row temp_row = new menu_row(m_text, item["count"].ToString(), price.ToString(), r_ind++);
                temp_row.dce += dbtn_event;
                temp_row.Dock = DockStyle.Top;
                Show_Counts.Controls.Add(temp_row);
            }
            order_count_lbl.Text = all_count.ToString();
            order_allprice_lbl.Text = all_price.ToString();

        }
        // update basic_bag & tlp_show_count
        public void h_click()
        {

            ord_cho_panel.Visible = true;
            ord_cho_panel.Size = new Size(580, 400);
            ord_cho_panel.Location = new Point(25, 0);
            scn_sound_out(12);
        }

        public void h_click_2()
        {
            ord_set_panel.Visible = true;
            ord_set_panel.Location = new Point(25, 0);
            set_c_btn.BackColor = Color.White;

            set_tpl_c.Visible = true;
        }

        private void ord_h_cancel_Click(object sender, EventArgs e)
        {
            ord_cho_panel.Visible = false;
            h_index = -1;
        }

        private void dbtn_event(object sender, EventArgs e)
        {
            Control temp = (Control)sender;
            menu_row ttemp = (menu_row)temp.Parent;
            basic_bag.RemoveAt(ttemp.s_inds);
            update_bag();
        }



        private void set_click(object sender, EventArgs e)
        {
            set_tpl_c.Visible = false;
            set_tpl_d.Visible = false;
            char[] delimi = { ' ', };
            char fword = sender.ToString().Split(delimi)[3][0];
            Control temp = (Control)sender;

            foreach (Control item in temp.Parent.Controls)
            {
                item.BackColor = Color.Pink;
            }
            switch (fword)
            {
                case '디':
                    label2.Text = "세트디저트 1개를 선택해 주세요";
                    set_c_btn.BackColor = Color.White;
                    set_tpl_c.Visible = true;

                    break;
                case '드':
                    label2.Text = "세트드링크 1개를 선택해 주세요";
                    set_d_btn.BackColor = Color.White;
                    set_tpl_d.Visible = true;

                    break;
                default:
                    break;
            }


        }
        // order_panel pink buttons



        private void ord_set_click(object sender, EventArgs e)
        {
            char[] delimi = { '_', };
            Button s_button = (Button)sender;
            if (s_button.Name.Split(delimi)[2] == "cancel")
            {
                h_basic_menu = new Dictionary<string, int>(basic_menu);
                ord_set_panel.Visible = false;
                ch_num_lbl.Text = "0";
                left_num_lbl.Text = "2";
                for (int i = 0; i < set_tpl_c.Controls.Count; i++)
                {
                    PictureBox d_border = (PictureBox)set_tpl_d.Controls[i];
                    PictureBox c_border = (PictureBox)set_tpl_c.Controls[i];
                    d_border.BorderStyle = BorderStyle.None;
                    c_border.BorderStyle = BorderStyle.None;

                }
            } //취소하기
            else
            {
                if (ch_num_lbl.Text == "2")
                {


                    for (int i = 0; i < set_tpl_c.Controls.Count; i++)
                    {
                        PictureBox d_border = (PictureBox)set_tpl_d.Controls[i];
                        PictureBox c_border = (PictureBox)set_tpl_c.Controls[i];
                        //MessageBox.Show(c_border.BorderStyle.ToString());
                        if (c_border.BorderStyle.ToString() == "Fixed3D")
                            h_basic_menu["c_key"] = i + 1;
                        if (d_border.BorderStyle.ToString() == "Fixed3D")
                            h_basic_menu["d_key"] = i + 1;
                    }
                    //MessageBox.Show(h_basic_menu["c_key"].ToString());
                    //MessageBox.Show(h_basic_menu["d_key"].ToString());
                    h_basic_menu["m_key"] = h_basic_menu["h_key"] * 10000 + h_basic_menu["c_key"] * 100 + h_basic_menu["d_key"];
                    overlap_check(h_basic_menu);
                    h_basic_menu = new Dictionary<string, int>(basic_menu);
                    ord_set_panel.Visible = false;
                    ch_num_lbl.Text = "0";
                    left_num_lbl.Text = "2";
                    for (int i = 0; i < set_tpl_c.Controls.Count; i++)
                    {
                        PictureBox d_border = (PictureBox)set_tpl_d.Controls[i];
                        PictureBox c_border = (PictureBox)set_tpl_c.Controls[i];
                        d_border.BorderStyle = BorderStyle.None;
                        c_border.BorderStyle = BorderStyle.None;

                    }
                }// 정상 선택
                else
                {
                    MessageBox.Show("please more pick!");
                }// 비정상 선택
            }

        }

        private void payment_ts_click(object sender, EventArgs e)
        {
            PictureBox spb = new PictureBox();
            spb = (PictureBox)sender;
            foreach (PictureBox item in payment_ts_panel.Controls)
            {
                item.BorderStyle = BorderStyle.None;
            }
            if (spb.Name == "payment_shop_pb")
            {
                payment_ts_count = 1;
                spb.BorderStyle = BorderStyle.Fixed3D;
                payment_ts_lbl.Text = "  매장식사를 선택하셨습니다.";
                scn_sound_out(7);
            }
            else
            {
                payment_ts_count = 2;
                spb.BorderStyle = BorderStyle.Fixed3D;
                payment_ts_lbl.Text = "  포장주문을 선택하셨습니다.";
                scn_sound_out(11);
            }



        }

        private void payment_pay_btn_Click(object sender, EventArgs e)
        {
            if (payment_ts_count == 0)
            {
                MessageBox.Show("Choose ts type pls!!");
            }
            else
            {
                scn_sound_out(8);
                payment_panel.Visible = false;
                orderfin_panel.Visible = true;
            }
        }

        private void payment_cancel_btn_Click(object sender, EventArgs e)
        {
            foreach (PictureBox item in payment_ts_panel.Controls)
            {
                item.BorderStyle = BorderStyle.None;
            }
            payment_ts_lbl.Text = " 포장/매장 여부 선택해주세요";
            order_panel.Visible = true;
            payment_panel.Visible = false;
            payment_ts_count = 0;
        }

        private void fin_pb_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KPlayer_Enter(object sender, EventArgs e)
        {

        }

        private void M_Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}