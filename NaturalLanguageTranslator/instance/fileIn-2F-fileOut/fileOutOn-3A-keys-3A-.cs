fileOutOn: aStream keys: keys 
	"self current fileOutOn: Transcript. Transcript endEntry"
	self fileOutHeaderOn: aStream.
	(keys
		ifNil: [generics keys asSortedCollection])
		do: [:key | self
				nextChunkPut: (generics associationAt: key)
				on: aStream].
	keys
		ifNil: [self untranslated
				do: [:each | self nextChunkPut: each -> '' on: aStream]].
	aStream nextPut: $!;
		 cr