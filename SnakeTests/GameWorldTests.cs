using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Tests
{
    [TestClass()]
    public class GameWorldTests
    {
        /// <summary>
        /// Tester för spelet. Kollar om food skapats och lagts till i listan Collect, när spelare plockar mat. Kollar om player läggs till i listan Collect vid Update.
        /// Själv tyckte jag att det är svårt för tester med denna typen av program, som spel. I miniräknaruppgiften var det mycket enklare att kunna testa de olika metoderna, då jag exakt visste resultatet som skulle ske. Jag skulle jättegärna vilja om du kunde ta upp tester lite mer, särkskilt kanske när det gäller denna uppgift. Då det var mycket klasser och konstruktorer behövde jag skapa upp instanser i de olika testerna. Jag hoppas det är så det är menat, jag känner mig lite osäker på detta.
        /// </summary>
        [TestMethod()]
        public void CreateFoodTest()
        {
            List<GameObject> lista = new List<GameObject>();
            List<Tail> bak = new List<Tail>();
            Player gamer = new Player(Direction.right, 'O', bak, 7, 4);



            ConsoleRenderer.SizeX = 50;
            ConsoleRenderer.SizeY = 20;

            Random ran = new Random();
            int ranx = ran.Next(1, ConsoleRenderer.SizeX - 3);
            int rany = ran.Next(1, ConsoleRenderer.SizeY - 3);
            Food foder = new Food('©', ranx, rany);

            GameWorld test = new GameWorld(0, lista, gamer, foder);

            test.playa.poss.X = 23;
            test.playa.poss.Y = 12;
            test.fodd.poss.X = 23;
            test.fodd.poss.Y = 12;

            test.CreateFood();
            Assert.AreEqual(1, test.Collect.Count);


        }

        [TestMethod()]
        public void UpdateTest()
        {
            List<GameObject> lista = new List<GameObject>();
            List<Tail> bak = new List<Tail>();
            Player gamer = new Player(Direction.right, 'O', bak, 7, 4);
            Random ran = new Random();
            int ranx = ran.Next(1, ConsoleRenderer.SizeX - 3);
            int rany = ran.Next(1, ConsoleRenderer.SizeY - 3);
            Food foder = new Food('©', ranx, rany);

            GameWorld test = new GameWorld(0, lista, gamer, foder);

            test.Collect.Add(gamer);

            test.Update();
            Assert.AreEqual(1, test.Collect.Count);
        }
    }
}