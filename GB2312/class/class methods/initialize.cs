initialize
"
	GB2312 initialize
"

	CompoundTextSequence _ String
				streamContents: 
					[:stream | 
					stream nextPut: Character escape.
					stream nextPut: $$.
					stream nextPut: $(.
					stream nextPut: $A].
