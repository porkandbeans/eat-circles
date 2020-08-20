using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bscript : MonoBehaviour
{
    public io.newgrounds.core ng_core;

    // Start is called before the first frame update
    void Start()
    {
        ng_core.onReady(() =>
        {
            ng_core.checkLogin(onLoginCheck);
        });
        
    }

    void onLoginCheck(bool logged_in)
    {
        if (logged_in)
        {
            unlockMedal(60231);
        }
    }

    // call this method whenever you want to unlock a medal.
    void unlockMedal(int medal_id)
    {
        // create the component
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();

        // set required parameters
        medal_unlock.id = medal_id;

        // call the component on the server, and tell it to fire onMedalUnlocked() when it's done.
        medal_unlock.callWith(ng_core, onMedalUnlocked);
    }

    // this will get called whenever a medal gets unlocked via unlockMedal()
    void onMedalUnlocked(io.newgrounds.results.Medal.unlock result)
    {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log("Medal Unlocked: " + medal.name + " (" + medal.value + " points)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
