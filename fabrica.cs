namespace Personajes
{
    public class FabricaDePersonajes
    {
        private Datos Datos = new Datos();
        private caracteristicas caracteristicas = new caracteristicas();
        public Datos CharaInfo {get => Datos; set => Datos = value;}
        public caracteristicas CharaStats {get => caracteristicas;  set => caracteristicas = value;}
        public void CrearPersonaje(Datos datos)
        {
            Random rnd = new Random();
            CharaInfo = datos;
            switch(CharaInfo.intAfinidad)
            {
                case 0: CharaInfo.affinity = Datos.Tipo.Saber; break;
                case 1: CharaInfo.affinity = Datos.Tipo.Archer; break;
                case 2: CharaInfo.affinity = Datos.Tipo.Lancer; break;
                case 3: CharaInfo.affinity = Datos.Tipo.Rider; break;
                case 4: CharaInfo.affinity = Datos.Tipo.Caster; break;
                case 5: CharaInfo.affinity = Datos.Tipo.Assassin; break;
                case 6: CharaInfo.affinity = Datos.Tipo.Berserker; break;
            }

            switch(CharaInfo.affinity)
            {
                case Datos.Tipo.Saber: CharaStats.speed = rnd.Next(8,11);
                        CharaStats.agility = rnd.Next(6,11);
                        CharaStats.attack = rnd.Next(8,11);
                        CharaStats.armor = rnd.Next(9,12);
                break;
                case Datos.Tipo.Lancer: CharaStats.speed = rnd.Next(10,13);
                        CharaStats.agility = rnd.Next(8,13);
                        CharaStats.attack = rnd.Next(7,10);
                        CharaStats.armor = rnd.Next(8,12);
                break;
                case Datos.Tipo.Archer: CharaStats.speed = rnd.Next(9,12);
                        CharaStats.agility = rnd.Next(2,10);
                        CharaStats.attack = rnd.Next(7,11);
                        CharaStats.armor = rnd.Next(8,12);
                break;
                case Datos.Tipo.Rider: CharaStats.speed = rnd.Next(8,11);
                        CharaStats.agility = rnd.Next(7,11);
                        CharaStats.attack = rnd.Next(8,11);
                        CharaStats.armor = rnd.Next(9,12);
                break;
                case Datos.Tipo.Caster: CharaStats.speed = rnd.Next(6,9);
                        CharaStats.agility = rnd.Next(5,10);
                        CharaStats.attack = rnd.Next(7,10);
                        CharaStats.armor = rnd.Next(8,12);
                break;
                case Datos.Tipo.Assassin: CharaStats.speed = rnd.Next(11,15);
                        CharaStats.agility = rnd.Next(11,15);
                        CharaStats.attack = rnd.Next(7,10);
                        CharaStats.armor = rnd.Next(5,8);
                break;
                case Datos.Tipo.Berserker: CharaStats.speed = rnd.Next(5,9);
                        CharaStats.agility = rnd.Next(1,6);
                        CharaStats.attack = rnd.Next(11,15);
                        CharaStats.armor = rnd.Next(11,15);
                break;
            }
            CharaStats.level = rnd.Next(1,11);
            if(CharaInfo.affinity == Datos.Tipo.Berserker)
            {
                CharaStats.HP = 125;
            }
            else
            {
                CharaStats.HP = 100;
            }
        }

        public void mostrarPersonaje()
        {
            Console.WriteLine("DATOS");
            Console.WriteLine($"Nombre/Apodo: {CharaInfo.Name}, {CharaInfo.Alias}");
            Console.WriteLine($"Fecha de Nacimiento: {CharaInfo.Birth.Day}/{CharaInfo.Birth.Month}/{CharaInfo.Birth.Year} - {CharaInfo.Age} años");
            Console.WriteLine("Clase: " + CharaInfo.affinity);
            Console.WriteLine("\nESTADISTICAS");
            Console.WriteLine("Nivel: " + CharaStats.level);
            Console.WriteLine("Ataque: " + CharaStats.attack);
            Console.WriteLine("Defensa: " + CharaStats.armor);
            Console.WriteLine("Velocidad: " + CharaStats.speed);
            Console.WriteLine("Agilidad: " + CharaStats.agility);
            Console.WriteLine("Vida: " + CharaStats.HP);
        }

        public int calcularEdad(DateTime nacimiento)
        {
            int anio = DateTime.Today.Year - nacimiento.Year;
            int mes = DateTime.Today.Month - nacimiento.Month;
            if(mes < 0) 
            { 
                anio -= 1; 
                mes += 12; 
            }
            int dia = DateTime.Today.Day - nacimiento.Day;
            if(dia < 0)
            {
                mes -= 1;
                if(mes < 0)
                {
                    anio -= 1;
                    mes += 12;
                }
                dia += 30; 
            }
            return anio;
        }
    }
}