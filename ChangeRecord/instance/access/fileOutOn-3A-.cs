fileOutOn: f
	type == #method
		ifTrue:
			[f nextPut: $!.
			f nextChunkPut: class asString
					, (meta ifTrue: [' class methodsFor: ']
							ifFalse: [' methodsFor: '])
					, category asString printString.
			f cr]
		ifFalse:
			[type == #preamble ifTrue: [f nextPut: $!]].
	f nextChunkPut: self string.
	type == #method ifTrue: [f nextChunkPut: ' '].
	f cr