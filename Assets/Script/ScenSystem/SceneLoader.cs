using UnityEngine.SceneManagement;

public static class SceneLoader 
{
    public static int previousScena;
    public static int currentScena;

    public static void LoadScen(int ScenaIndex)
    {
        previousScena = SceneManager.GetActiveScene().buildIndex;
        currentScena = ScenaIndex;
        SceneManager.LoadScene(ScenaIndex);   
    }

    public static void PreviousScena() =>    
        SceneManager.LoadScene(previousScena);
}
