cByteOp: opIndex short: pByteShort len: shortLen long: pByteLong len: longLen into: pByteRes 
	"pByteRes len = longLen."
	| limit |
	self var: #pByteShort declareC: 'unsigned char * pByteShort'.
	self var: #pByteLong declareC: 'unsigned char * pByteLong'.
	self var: #pByteRes declareC: 'unsigned char * pByteRes'.
	self var: #shortLen declareC: 'int shortLen'.
	self var: #longLen declareC: 'int longLen'.
	self var: #limit declareC: 'int limit'.
	limit _ shortLen - 1.
	opIndex = andOpIndex
		ifTrue: 
			[0 to: limit do: [:i | pByteRes at: i put: ((pByteShort at: i)
						bitAnd: (pByteLong at: i))].
			limit _ longLen - 1.
			shortLen to: limit do: [:i | pByteRes at: i put: 0].
			^ 0].
	opIndex = orOpIndex
		ifTrue: 
			[0 to: limit do: [:i | pByteRes at: i put: ((pByteShort at: i)
						bitOr: (pByteLong at: i))].
			limit _ longLen - 1.
			shortLen to: limit do: [:i | pByteRes at: i put: (pByteLong at: i)].
			^ 0].
	opIndex = xorOpIndex
		ifTrue: 
			[0 to: limit do: [:i | pByteRes at: i put: ((pByteShort at: i)
						bitXor: (pByteLong at: i))].
			limit _ longLen - 1.
			shortLen to: limit do: [:i | pByteRes at: i put: (pByteLong at: i)].
			^ 0].
	^ interpreterProxy primitiveFail