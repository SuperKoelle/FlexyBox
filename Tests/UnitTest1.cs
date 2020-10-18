using FlexyBox;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        #region Kommentarer til FlexyBox
        // Disse kommentarer er her blot for at uddybe overvejelser jeg har haft under udvikling. Disse ville ikke være noteret på samme
        // måde, hvis dette var et produkt til en kunde.
        // 
        // Testene er lavet alene for at vise overvejelser omkring, hvad der bør testes efter 
        // i unittests; krav fra "opgavestiller/kunde", samt best-practive erfaringer. Alt efter hvilket 
        // framework, der bruges kan gruppering af tests mm. kan gøres bedre.
        //
        // Tests for "Reflexion" er udkommenteret, da de samme tests bliver dækket i tests af "Funktionalitet".
        //
        // Testene faker/mocker ikke Microsoft komponenter (Console og StreamWriter). Disse forventes at virke. For at holde arkitekturen simple i denne 
        // løsning testes på resultatet af StreamWriter. Alternativt kunne metoderne i FileWriter klassen deles op, for at lave specifikke tests at det,
        // der kommer ind og det, der sende til StreamWriteren.
        //
        // Der testes ikke for ikke at bruge String.Reverse(), der testes ej heller for om reflexion rent faktisk understøtter andre typer. Begge dele 
        // virker lidt overflødige at teste for. Her kunne man dog høre opgavestiller/kunden om det var krav, der var vigtige nok til at blive testet for.
        //
        // Exceptions fra eksempelvis IO håndteres ikke. Der er heller ikke test for om disse kastes rigtigt. Dette vurderes ikke til at være ønsket for
        // denne løsning.
        //
        // Tests kan afvikles med "dotnet test Tests/Tests.csproj" i Visual Studio Code.
        #endregion

        private readonly InstanceService instanceService;

        public UnitTest1()
        {
            instanceService = new InstanceService();
        }

 /*        #region InstanceService.GetInstances tests
        [Fact]
        public void instanceService_GetInstances_1()
        {
            var p = (List<Vehicle>) instanceService.GetInstances<Vehicle>();

            Assert.Equal(4, p.Count);
        }

        [Fact]
        public void instanceService_GetInstances_2()
        {
            var p = (List<Car>) instanceService.GetInstances<Car>();

            Assert.Equal(1, p.Count);
        }

        [Fact]
        public void instanceService_GetInstances_3()
        {
            var p = (List<String>) instanceService.GetInstances<String>();

            Assert.Equal(0, p.Count);
        }
        #endregion

        #region InstanceService.SearchTypes tests
        [Fact]
        public void instanceService_SearchTypes_positive_1()
        {
            var p = (List<Type>) instanceService.SearchTypes("car");

            Assert.Equal(2, p.Count);
        }

        [Fact]
        public void instanceService_SearchTypes_positive_2()
        {
            var p = (List<Type>) instanceService.SearchTypes("CAR");

            Assert.Equal(2, p.Count);
        }

        [Fact]
        public void instanceService_SearchTypes_positive_3()
        {
            var p = (List<Type>) instanceService.SearchTypes("bi");

            Assert.Equal(1, p.Count);
        }
        [Fact]
        public void instanceService_SearchTypes_negative_4()
        {
            var p = (List<Type>) instanceService.SearchTypes("zx");

            Assert.Equal(0, p.Count);
        }
        #endregion  
 */
        
        #region Tests af "Funktionalitet"
        [Fact]
        public void Functionaly_1()
        {
            var p = (List<Vehicle>) Program.GetAndSortTypes<Vehicle>();

            Assert.Equal(4, p.Count);
            Assert.Equal(p[0].GetType().Name, "Bicycle");
            Assert.Equal(p[1].GetType().Name, "BumperCar");
            Assert.Equal(p[2].GetType().Name, "Car");
            Assert.Equal(p[3].GetType().Name, "Vehicle");
        }

        [Fact]
        public void Functionaly_2()
        {
            var p = (List<Vehicle>) Program.GetSearchedTypes<Vehicle>("car");

            foreach (var instance in p)
            {
                Assert.Equal(true, instance.GetType().Name.ToLower().Contains("car".ToLower()));                
            }

            Assert.Equal(2, p.Count);
        }     

        [Fact]
        public void Functionaly_3()
        {
            var p = (List<Vehicle>) Program.GetSearchedTypes<Vehicle>("Car");

            foreach (var instance in p)
            {
                Assert.Equal(true, instance.GetType().Name.ToLower().Contains("Car".ToLower()));            
            }

            Assert.Equal(2, p.Count);
        }       

        [Fact]
        public void Functionaly_4()
        {
            var p = (List<Vehicle>) Program.GetSearchedTypes<Vehicle>("bi");

            foreach (var instance in p)
            {
                Assert.Equal(true, instance.GetType().Name.ToLower().Contains("bi".ToLower()));            
            }

            Assert.Equal(1, p.Count);
        }

        [Fact]
        public void Functionaly_5()
        {
            var p = (List<Vehicle>) Program.GetSearchedTypes<Vehicle>("zx");

            Assert.Equal(0, p.Count);
        }    

        [Fact]
        public void Functionaly_6()
        {
            File.Delete("FileWriterTest");
            
            FileWriter.WriteTypesToFile("FileWriterTest", new[] { "line1"});
            
            Assert.Equal(true, File.Exists("FileWriterTest"));
            Assert.Equal(true, File.ReadAllLines("FileWriterTest").First().GetType() == "line1".GetType());

            File.Delete("FileWriterTest");
        }    
        #endregion

        #region Tests af "Problemløsning"
        [Fact]
        public void Problemsolving_1()
        {
            var reversedString = Problemsolving.ReverseString("FlexyBox samler hele din drift i et system, og frigiver tid til dine kunder.");

            Assert.Equal(".rednuk enid lit dit revigirf go ,metsys te i tfird nid eleh relmas xoByxelF", reversedString);
        }  

        [Fact]
        public void Problemsolving_2()
        {
            Assert.Equal(true, Problemsolving.IsPalindrome("beeb"));
        }

        [Fact]
        public void Problemsolving_3()
        {
            Assert.Equal(false, Problemsolving.IsPalindrome("not"));
        }  

        [Fact]
        public void Problemsolving_4()
        {
            var arr2 = (int[]) Problemsolving.MissingElements(new int[] {4,6,9});
            Assert.Equal(new int[] {5,7,8}, arr2);
        }  

        [Fact]
        public void Problemsolving_5()
        {
            var arr2 = (int[]) Problemsolving.MissingElements(new int[] {2,3,4});
            Assert.Equal(new int[] {}, arr2);
        }  

        [Fact]
        public void Problemsolving_6()
        {
            var arr2 = (int[]) Problemsolving.MissingElements(new int[] {1,3,4});
            Assert.Equal(new int[] {2}, arr2);
        }  
        #endregion
    }
}
