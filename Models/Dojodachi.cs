using System;
namespace Dojodachi.Models
{
// Your Dojodachi should start with 20 happiness, 20 fullness, 50 energy, and 3 meals.
    public class dojodachi
    {
        private int? Fullness;
        private int? Happiness;
        private int? Meals;
        private int? Energy;
        public int fullness
        {
            get
            {
                if (Fullness == null )
                {
                    return 20;
                    
                }
                return (int) Fullness;
            }
            set 
            {
                Fullness =(int?)value;
            }
        }    
        public int happiness
        { 
            get
            {
                if (Happiness == null)
                {
                    return 20;
                }
                return (int)Happiness;
                }   
            set
            {
                Happiness = (int?)value;
            }
        }
        public int meals
        {
            get 
            {
                if(Meals == null)
                {
                    return 3;
                }
                return (int)Meals;
            }

            set
            {
                Meals=(int?)value;
            }
        }   
        public int energy
        {
            get
            {
                if(Energy==null)
                {
                    return 50;
                }
                return (int)Energy;
            }
            set
            {
                Energy=(int?)value;
            }
        }
        public dojodachi()
        {
            Fullness=20;
            Happiness=20;
            Meals=3;
            Energy=50;

        }

        public dojodachi(int? f, int? h, int? m, int? e)
        {
            Fullness=f;
            Happiness=h;
            Meals=m;
            Energy=e;
        }
// Feeding your Dojodachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals)
        public string Feed()
        {
            if (meals ==0)
            {
                return "you cant afford food :(";
            }
            else
            {
                Random rInt = new Random();
                int luck = rInt.Next(1,5);
                if (luck == 1)
                {
                    meals --;
                    return "what is this peasant food!?";
                }
                else
                {
                    meals --;
                    int sustinance = rInt.Next(5,10);
                    fullness += sustinance;
                    return $"Dojodachi Liked that! Fullness +{sustinance}, Meals -1.";
                }
            }
        }
// Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
// Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
        public string Play()
        {
            if (energy < 5)
            {
                return "Dojodachi is too tired to play right now bro";
            }
            else
            {
                Random rInt = new Random();
                int luck=rInt.Next(1,5);
                if(luck==1)
                {
                    energy -=5;
                    return "woah calm down Lenny";
                }
                else
                {
                    energy -=5;
                    int joy = rInt.Next(5,10);
                    happiness += joy;
                    return $"awww so cute, Happiness +{joy}, energy -5."; 
                }
            }
        }

// Working costs 5 energy and earns between 1 and 3 meals
        public string Work()
        {
            if (energy < 5)
            {
                return "what is this soviet russia!? Im too tired to work!";
            }
            else
            {
                Random rInt = new Random();
                int paycheck = rInt.Next(1,3);
                meals += paycheck;
                return $"work all day what do ya get? another day older and {paycheck} more Meal tickets...";
            }
        }

// Sleeping earns 15 energy and decreases fullness and happiness each by 5
        public string Sleep()
        {
            // if(fullness < 5 || happiness < 5)
            // {
            //     return "too hungry or too cranky to sleep";
            // }
            // else
            // {
                fullness -= 5;
                happiness -= 5;
                energy += 15;
                return "ahhh that was relaxing. Dojodachi gained 15 energy but lost 5 fullness happiness";
            // }
        }
// If energy, fullness, and happiness are all raised to over 100, you win! a restart button should be displayed.

        public bool win()
        {
            if (energy >=100 && happiness >=100 && fullness >=100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
// If fullness or happiness ever drop to 0, you lose, and a restart button should be displayed.

        public bool loose()
        {
            if (energy ==0 ||happiness==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}