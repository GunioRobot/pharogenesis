commonVariableInternal: rcvr at: index cacheIndex: atIx 
	"This code assumes the reciever has been identified at location atIx in the atCache."
	| stSize fmt fixedFields result |
	self inline: true.

	stSize _ atCache at: atIx+AtCacheSize.
	((self cCoerce: index to: 'unsigned ') >= 1
		and: [(self cCoerce: index to: 'unsigned ') <= (self cCoerce: stSize to: 'unsigned ')])
	ifTrue:
		[fmt _ atCache at: atIx+AtCacheFmt.
		fmt <= 4 ifTrue:
			[fixedFields _ atCache at: atIx+AtCacheFixedFields.
			^ self fetchPointer: index + fixedFields - 1 ofObject: rcvr].
		fmt < 8 ifTrue:  "Bitmap"
			[result _ self fetchWord: index - 1 ofObject: rcvr.
			self externalizeIPandSP.
			result _ self positive32BitIntegerFor: result.
			self internalizeIPandSP.
			^ result].
		fmt >= 16  "Note fmt >= 16 is an artificial flag for strings"
			ifTrue: "String"
			[^ self characterForAscii: (self fetchByte: index - 1 ofObject: rcvr)]
			ifFalse: "ByteArray"
			[^ self integerObjectOf: (self fetchByte: index - 1 ofObject: rcvr)]].

	self primitiveFail