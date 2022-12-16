using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotFuzzy;
namespace AliacFuzzyLogic
{
    public partial class Form1 : Form
    {
        FuzzyEngine fe;
        MembershipFunctionCollection speed,distance,brake;
        LinguisticVariable myspeed, mydistance, mybrake;
        FuzzyRuleCollection myrules;
        

        public Form1()
        {
            InitializeComponent();
        }

    
        public void setMembers()
        {

            speed = new MembershipFunctionCollection();
            speed.Add(new MembershipFunction("VVSLOW",0.0,0.0,0.0,40.0));
            speed.Add(new MembershipFunction("VSLOW", 30.0, 35.0, 45.0, 50.0));
            speed.Add(new MembershipFunction("SLOW", 55.0, 69.5, 70.5, 85.0));
            speed.Add(new MembershipFunction("MEDIUM", 80.0, 95.0, 125.0, 140.0));
            speed.Add(new MembershipFunction("FAST", 130.0, 155.0, 155.5, 180.0));
            speed.Add(new MembershipFunction("VFAST", 170.0, 195.5, 196.5, 220.0));
            speed.Add(new MembershipFunction("VVFAST", 210.0, 225.0, 260.0, 260.0));
            myspeed = new LinguisticVariable("SPEED", speed);


            distance = new MembershipFunctionCollection();
            distance.Add(new MembershipFunction("VCLOSE", 0.0, 0.0, 20.0, 50.0));
            distance.Add(new MembershipFunction("CLOSE", 40.0, 65.0, 65.5, 90.0));
            distance.Add(new MembershipFunction("MEDIUM", 80.0, 120.0, 120.0, 160.0));
            distance.Add(new MembershipFunction("FAR", 150.0, 174.5, 175.0, 200.0));
            mydistance = new LinguisticVariable("DISTANCE", distance);

            brake = new MembershipFunctionCollection();
            brake.Add(new MembershipFunction("VSMALL",0.0,0.0,0.0,15.0));
            brake.Add(new MembershipFunction("SMALL", 10.0, 20.0, 20.0, 30.0));
            brake.Add(new MembershipFunction("MEDIUM", 25.0, 40.0, 40.0, 55.0));
            brake.Add(new MembershipFunction("FULL", 50.0, 62.0, 62.0, 75.0));
            brake.Add(new MembershipFunction("VFULL", 70.0, 90.0, 90.0, 90.0));
            mybrake = new LinguisticVariable("BRAKE", brake);

            
        
        }

        public void setRules()
        {
          myrules = new FuzzyRuleCollection();
          //VVSLOW
          myrules.Add(new FuzzyRule("IF (SPEED IS VVSLOW) AND (DISTANCE IS VCLOSE) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VVSLOW) AND (DISTANCE IS CLOSE) THEN BRAKE IS VSMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VVSLOW) AND (DISTANCE IS MEDIUM) THEN BRAKE IS VSMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VVSLOW) AND (DISTANCE IS FAR) THEN BRAKE IS VSMALL"));
          //VSLOW
          myrules.Add(new FuzzyRule("IF (SPEED IS VSLOW) AND (DISTANCE IS VCLOSE) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VSLOW) AND (DISTANCE IS CLOSE) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VSLOW) AND (DISTANCE IS MEDIUM) THEN BRAKE IS VSMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VSLOW) AND (DISTANCE IS FAR) THEN BRAKE IS VSMALL"));
          //SLOW
          myrules.Add(new FuzzyRule("IF (SPEED IS SLOW) AND (DISTANCE IS VCLOSE) THEN BRAKE IS MEDIUM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS SLOW) AND (DISTANCE IS CLOSE) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS SLOW) AND (DISTANCE IS MEDIUM) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS SLOW) AND (DISTANCE IS FAR) THEN BRAKE IS VSMALL"));
          //MEDIUM
          myrules.Add(new FuzzyRule("IF (SPEED IS MEDIUM) AND (DISTANCE IS VCLOSE) THEN BRAKE IS FULL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS MEDIUM) AND (DISTANCE IS CLOSE) THEN BRAKE IS MEDIUM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS MEDIUM) AND (DISTANCE IS MEDIUM) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS MEDIUM) AND (DISTANCE IS FAR) THEN BRAKE IS VSMALL"));
          //FAST
          myrules.Add(new FuzzyRule("IF (SPEED IS FAST) AND (DISTANCE IS VCLOSE) THEN BRAKE IS VFULL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS FAST) AND (DISTANCE IS CLOSE) THEN BRAKE IS MEDIUM"));
          myrules.Add(new FuzzyRule("IF (SPEED IS FAST) AND (DISTANCE IS MEDIUM) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS FAST) AND (DISTANCE IS FAR) THEN BRAKE IS SMALL"));
          //VFAST
          myrules.Add(new FuzzyRule("IF (SPEED IS VFAST) AND (DISTANCE IS VCLOSE) THEN BRAKE IS VFULL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VFAST) AND (DISTANCE IS CLOSE) THEN BRAKE IS FULL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VFAST) AND (DISTANCE IS MEDIUM) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VFAST) AND (DISTANCE IS FAR) THEN BRAKE IS SMALL"));
          //VVFAST
          myrules.Add(new FuzzyRule("IF (SPEED IS VVFAST) AND (DISTANCE IS VCLOSE) THEN BRAKE IS VFULL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VVFAST) AND (DISTANCE IS CLOSE) THEN BRAKE IS VFULL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VVFAST) AND (DISTANCE IS MEDIUM) THEN BRAKE IS SMALL"));
          myrules.Add(new FuzzyRule("IF (SPEED IS VVFAST) AND (DISTANCE IS FAR) THEN BRAKE IS SMALL"));
        }

        public void setFuzzyEngine()
        {
            fe = new FuzzyEngine();
            fe.LinguisticVariableCollection.Add(myspeed);
            fe.LinguisticVariableCollection.Add(mydistance);
            fe.LinguisticVariableCollection.Add(mybrake);
            fe.FuzzyRuleCollection = myrules;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void defuziffyToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setMembers();
            setRules();
            //setFuzzyEngine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myspeed.InputValue=(Convert.ToDouble(textBox1.Text));
            myspeed.Fuzzify("SLOW");
            
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            mydistance.InputValue = (Convert.ToDouble(textBox2.Text));
            mydistance.Fuzzify("MEDIUM");
            
        }

        public void fuziffyvalues()
        {
            myspeed.InputValue = (Convert.ToDouble(textBox1.Text));
            myspeed.Fuzzify("VVSLOW");
            mydistance.InputValue = (Convert.ToDouble(textBox2.Text));
            mydistance.Fuzzify("VCLOSE");
        
        }
        public void defuzzy()
        {
            setFuzzyEngine();
            fe.Consequent = "BRAKE";
            textBox3.Text = "" + fe.Defuzzify();
        }

        public void computenewspeed()
        {

            double oldspeed = Convert.ToDouble(textBox1.Text);
            double oldbrake = Convert.ToDouble(textBox3.Text);
            double olddistance = Convert.ToDouble(textBox2.Text);
            double newspeed = ((1 - 0.1) * (oldspeed)) - (oldbrake - (0.1 * olddistance));
            textBox1.Text = "" + newspeed;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            setFuzzyEngine();
            fe.Consequent = "BRAKE";
            textBox3.Text = "" + fe.Defuzzify();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            computenewspeed();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            setMembers();
            setRules();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fuziffyvalues();
            defuzzy();
            computenewspeed();
        }

       
    }
}
