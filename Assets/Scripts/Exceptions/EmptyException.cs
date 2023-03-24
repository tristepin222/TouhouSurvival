using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EmptyException : Exception
{
    public class EmptyEffectPlayerException : EmptyException { }
    public class EmptyRigidbody2DException : EmptyException { }
    public class EmptyFightSystemException : EmptyException { }
}
