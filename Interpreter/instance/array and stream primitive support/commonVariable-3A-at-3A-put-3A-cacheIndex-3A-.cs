commonVariable: rcvr at: index put: value cacheIndex: atIx
	"This code assumes the reciever has been identified at location atIx in the atCache."
	| stSize fmt fixedFields valToPut |
	self inline: true.

	stSize _ atCache at: atIx+AtCacheSize.
	((self cCoerce: index to: 'unsigned ') >= 1
		and: [(self cCoerce: index to: 'unsigned ') <= (self cCoerce: stSize to: 'unsigned ')])
	ifTrue:
		[fmt _ atCache at: atIx+AtCacheFmt.
		fmt <= 4 ifTrue:
			[fixedFields _ atCache at: atIx+AtCacheFixedFields.
			^ self storePointer: index + fixedFields - 1 ofObject: rcvr withValue: value].
		fmt < 8 ifTrue:  "Bitmap"
			[valToPut _ self positive32BitValueOf: value.
			successFlag ifTrue: [self storeWord: index - 1 ofObject: rcvr withValue: valToPut].
			^ nil].
		fmt >= 16  "Note fmt >= 16 is an artificial flag for strings"
			ifTrue: [valToPut _ self asciiOfCharacter: value.
					successFlag ifFalse: [^ nil]]
			ifFalse: [valToPut _ value].
		(self isIntegerObject: valToPut) ifTrue:
			[valToPut _ self integerValueOf: valToPut.
			((valToPut >= 0) and: [valToPut <= 255]) ifFalse: [^ self primitiveFail].
			^ self storeByte: index - 1 ofObject: rcvr withValue: valToPut]].

	self primitiveFail