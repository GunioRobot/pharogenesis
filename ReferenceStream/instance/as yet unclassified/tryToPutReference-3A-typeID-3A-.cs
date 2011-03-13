tryToPutReference: anObject typeID: typeID
    "PRIVATE -- If we support references for type typeID, and if
       anObject already appears in my output stream, then put a
       reference to the place where anObject already appears. If we
       support references for typeID but didn’t already put anObject,
       then associate the current stream position with anObject in
       case one wants to nextPut: it again.
     Return true after putting a reference; false if the object still
       needs to be put.
     11/15/92 jhm: Added support for weak refs. Split out outputReference:."
    | referencePosn nextPosn |

    "Is it a reference type of object?"
    (self isAReferenceType: typeID) ifFalse: [^ false].

    "Have we heard of and maybe even written anObject before?"
    referencePosn _ references
              at: anObject
        ifAbsent:   "Nope. Remember it and let the sender write it."
            [references at: anObject put: byteStream position.
            ^ false].

    "If referencePosn is an Integer, it's the stream position of anObject."
    (referencePosn isKindOf: Integer) ifTrue:
        [self outputReference: referencePosn.
        ^ true].

    "Else referencePosn is a collection of positions of weak-references to anObject.
     Make them full references since we're about to really write anObject."
    references at: anObject put: (nextPosn _ byteStream position).
    referencePosn do:
        [:weakRefPosn |
            byteStream position: weakRefPosn.
            self outputReference: nextPosn].
    byteStream position: nextPosn.
    ^ false