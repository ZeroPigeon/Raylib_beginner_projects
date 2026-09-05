public class Food
{
    
    public int X;
    public int Y;

    public void create()
    {
        
        Random random = new Random();

        X = random.Next(0, 800) / 20;
        Y = random.Next(200, 800) / 20;

    }   

}