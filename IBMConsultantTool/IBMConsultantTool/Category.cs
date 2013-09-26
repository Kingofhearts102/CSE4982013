using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;

namespace IBMConsultantTool
{
    public class Category : Panel
    {
        private BusinessObjective lastClicked;
        private string name;
        private int objectivesCount = 0;
        //private int objectiveCount = 0;
       // private TreeView treeView;
       // private this this;
        private int baseCategoryHeight = 100;
        private int baseCategoryWidth = 200;
        private int labelHeight = 20;
        public string test = "hello";
        private int totalHeight = 0;
        public string testgf = "hello";
        [XmlIgnore()]
        private List<BusinessObjective> objectives = new List<BusinessObjective>();
     //   private LinkedList<BusinessObjective> objectiveLinkedList = new LinkedList<BusinessObjective>();
        private BOMRedesign owner;
        //constructor
        public Category(/*BOMRedesign owner, string name*/ )
        {
            //this.name = name;
            //this.owner = owner;
            this.BackColor = Color.Orange;
            this.Visible = true;
            //this.Location = FindLocation();
            this.Height = baseCategoryHeight;
            this.Width = baseCategoryWidth;
            this.BorderStyle = BorderStyle.Fixed3D;
            //owner.Controls.Add(this);
            this.SetScrollState(2, true);

            MakeLabel();
        }

 


        public BOMRedesign Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                owner.Controls.Add(this);
            }
        }
        public Point FindLocation()
        {
            Point p = new Point();
            Console.WriteLine(Owner.Width.ToString());
            if (baseCategoryWidth * Owner.CategoryCount < Owner.Width)
            
                p.X = (Owner.CategoryCount * baseCategoryWidth) +1;



            return p;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    


        //public this Category

        public void AddObjective(string name)
        {
            objectivesCount++;
            BusinessObjective objective = new BusinessObjective(this, name);
            this.Controls.Add(objective);
           // objectiveLinkedList.AddLast(objective);
            objectives.Add(objective);
            UpdateCategoryHeight();
            objective.Click += new EventHandler(objective_Click);
            


        }

        private void objective_Click(object sender, EventArgs e)
        {
            BusinessObjective obj = (BusinessObjective)sender;
            Console.WriteLine(obj.Name);
            lastClicked = obj;
            owner.LastClickedCategory = obj.Owner;

        }

        public BusinessObjective LastClicked
        {
            get
            {
                return lastClicked;
            }
            set
            {
                lastClicked = value;
                owner.LastClickedCategory = value.Owner;
            }
        }

        public List<BusinessObjective> Objectives
        {
            get
            {
                return objectives;
            }
        }
        public int BusinessObjectivesCount
        {
            get
            {
                return objectivesCount;
            }
        }

        private void MakeLabel()
        {
            Label nameLabel = new Label();
            this.Controls.Add(nameLabel);
            nameLabel.BorderStyle = BorderStyle.FixedSingle;
            nameLabel.Location = new Point(0, 0);
            nameLabel.BackColor = Color.Red;
            nameLabel.Text = name;
            nameLabel.ForeColor = Color.White;
            nameLabel.Width = nameLabel.Parent.Width;
            nameLabel.Height = labelHeight;
            


        }
        public Point ObjectivePlacement()
        {
            Point point = new Point();
            point.X = 0;
            point.Y = labelHeight + 5 +  BusinessObjective.ObjectiveHeight * (objectivesCount -1);
            return point;
        }

        public void UpdateCategoryHeight()
        {
            int neededHeight = labelHeight;
            for (int i = 0; i < objectives.Count; i++)
            {
                if (i == 0)
                {
                    neededHeight += objectives[i].Height;
                    continue;
                }
                Point point = new Point();
                point.Y = /*(objectives[i - 1].InitiativesCount * 20)*/ + neededHeight +5; 
                neededHeight += objectives[i].Height;
                objectives[i].Location = point;
            }

            this.Height = labelHeight + neededHeight;// (objectivesCount * BusinessObjective.ObjectiveHeight);
            if (this.Height < baseCategoryHeight)
                this.Height = baseCategoryHeight;
        }

        public void AddToHeight(int amount)
        {
            totalHeight += amount;
        }

    } // end of class
}