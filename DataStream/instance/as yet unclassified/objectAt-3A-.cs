objectAt: anInteger
    "PRIVATE -- Read & return the object at a given stream position.
     11/16/92 jhm: Renamed local variable to not clash with an instance variable."
    | savedPosn anObject refPosn |

    savedPosn _ byteStream position.
    refPosn _ self getCurrentReference.

    byteStream position: anInteger.
    anObject _ self next.

    self setCurrentReference: refPosn.
    byteStream position: savedPosn.
    ^ anObject