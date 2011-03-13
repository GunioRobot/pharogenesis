keysAndValuesDo: aBlock
	"Enumerate the receiver with all the keys and values."
	^properties ifNotNil:[properties keysAndValuesDo: aBlock]