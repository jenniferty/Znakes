using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void BombIsCreated()
    {
        //GameObject[] bomb = SpawnPickUp();
        //assert object exists
        //Assert.IsNotNull(bomb);
    }
    //Test bomb disappears if player does not interact with it within time limit
    [Test]
    public void BombDisappearsAtTimeLimit()
    {
        //Time.timeScale = 20.0f;
        //float time = 0;
        

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
