nextPutAll: aCollection

	(self isBinary or: [aCollection class == ByteArray]) ifTrue: [
		^ super nextPutAll: aCollection.
	].
	aCollection do: [:e | self nextPut: e].
