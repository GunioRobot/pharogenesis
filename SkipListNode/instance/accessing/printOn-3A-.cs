printOn: aStream
        | first |
        aStream
                nextPut: $[.
        super printOn: aStream.
        aStream
                nextPutAll: ']-->('.
        first _ true.
        pointers do: [:node |
                first ifTrue: [first _ false] ifFalse: [aStream space].
                node ifNil: [aStream nextPutAll: '*'] 
                ifNotNil: [node printOn: aStream]].
        aStream nextPut: $)
