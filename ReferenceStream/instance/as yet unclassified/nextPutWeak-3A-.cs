nextPutWeak: anObject
    "Write a weak reference to anObject to the receiver stream. Answer anObject.
     If anObject is not a reference type of object, then just put it normally.
     A 'weak' reference means: If anObject gets written this stream via nextPut:,
     then its weak references will become normal references. Otherwise they'll
     read back as nil. -- 11/15/92 jhm"
    | typeID referencePosn |

    "Is it a reference type of object? If not, just write it normally."
    typeID _ self typeIDFor: anObject.
    (self isAReferenceType: typeID) ifFalse: [^ self nextPut: anObject].

    "Have we heard of and maybe even written anObject before?"
    referencePosn _ references
              at: anObject
        ifAbsent: [references at: anObject put: OrderedCollection new].

    "If referencePosn is an Integer, it's the stream position of anObject.
     Else it's a collection of hopeful weak-references to anObject."
    (referencePosn isKindOf: Integer) ifFalse:
        [referencePosn add: byteStream position.
        referencePosn _ self vacantRef].
    self outputReference: referencePosn.

    ^ anObject