nextPutAll: aCollection
	"Optimized for ByteArrays"
	aCollection class == ByteArray 
		ifTrue:[^super nextPutAll: aCollection asString].
	^super nextPutAll: aCollection