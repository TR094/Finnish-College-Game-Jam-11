using UnityEngine;

public class DrawerItem : MonoBehaviour
{
    public Drawer drawer;

    public void Taken()
    {
        if (drawer != null)
        {
            drawer.ItemTaken();
        }
    }
}
