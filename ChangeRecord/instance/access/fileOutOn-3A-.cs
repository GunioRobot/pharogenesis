fileOutOn: f
	type == #method
		ifTrue:
			[f nextPut: $!.
			f nextChunkPut: class asString
					, (meta ifTrue: [' class methodsFor: ']
							ifFalse: [' methodsFor: '])
					, category asString printString.
			f cr].

	type == #preamble ifTrue: [f nextPut: $!].

	type == #classComment
		ifTrue:
			[f nextPut: $!.
			f nextChunkPut: class asString, ' commentStamp: ', stamp storeString.
			f cr].

	f nextChunkPut: self string.
	type == #method ifTrue: [f nextChunkPut: ' '].
	f cr