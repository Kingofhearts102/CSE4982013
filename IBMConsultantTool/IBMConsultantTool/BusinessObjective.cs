using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace IBMConsultantTool
{
   public class BusinessObjective : Panel
    {
        BusinessObjective lastClicked;
        private string name;
        private Category owner;
        private int initiativesCount;
        private List<Initiative> initiatives = new List<Initiative>();
        private static int baseObjectiveHeight = 50;
        private int labelHeight = 20;
        //private int baseObjectiveHeight = ;

        public BusinessObjective(Category owner, string name)
        {
            this.owner = owner;
            this.name = name;
            this.BackColor = Color.Teal;
            //this.Text = name + "ahahahahahahahahaha";
            this.ForeColor = Color.Red;
            // objective.Name = name;
            this.Height = baseObjectiveHeight;
            this.Width = owner.Width;
            this.Visible = true;
            this.BorderStyle = BorderStyle.Fixed3D;
            MakeLabel();
            this.Click += new EventHandler(objective_Click);
            this.Location = owner.ObjectivePlacement();
            owner.AddToHeight(this.Height);
            

        }

        private void objective_Click(object sender, EventArgs e)
        {
            BusinessObjective obj = (BusinessObjective)sender;
            Console.WriteLine(obj.Name);
            lastClicked = obj;
            
            owner.LastClicked = obj;
           // ExpandObjective();
            

        }

        private void MakeLabel()
        {
            Label nameLabel = new Label();
            this.Controls.Add(nameLabel);
            nameLabel.BorderStyle = BorderStyle.FixedSingle;
            nameLabel.Location = new Point(0, 0);
            nameLabel.BackColor = Color.PowderBlue;
            nameLabel.Text = name;
            nameLabel.ForeColor = Color.Black;
            nameLabel.Width = nameLabel.Parent.Width;
            nameLabel.Height = labelHeight;



        }



        public string Name
        {
            get
            {
                return name;
            }
        }
        public Category Owner
        {
            get
            {
                return owner;
            }
        }

        public void AddInitiative(string name)
        {
            initiativesCount++;
            Initiative initiative = new Initiative(this, name);
            initiatives.Add(initiative);
            UpdateObjectiveHeight(initiative);
            //Console.WriteLine(name + "belongs to " + this.name + "which belongs to " + Owner.Name);
        }

        public List<Initiative> Initiatives
        {
            get
            {
                return initiatives;
            }
        }



        public int InitiativesCount
        {
            get
            {
                return initiativesCount;
            }
        }
        public static int ObjectiveHeight
        {
            get
            {
                return baseObjectiveHeight; 
            }
        }

        public Point InitiativePlacement(Initiative init)
        {
            Point point = new Point();
            point.X = 20;
            point.Y = labelHeight + 5 + (20 * (initiativesCount -1));
            return point;
        }

        public void UpdateObjectiveHeight(Initiative init)
        {
            this.Height = labelHeight + ((initiativesCount) * init.Height) + 10;
            if (this.Height < baseObjectiveHeight)
                this.Height = baseObjectiveHeight;


            owner.UpdateCategoryHeight();
        }
    }
}
