cDigitMultiply: pByteShort len: shortLen with: pByteLong len: longLen into: pByteRes 
	"pByteRes len = longLen * shortLen"
	| limitLong digit k carry limitShort ab |
	self returnTypeC: 'unsigned char'.
	self var: #pByteShort declareC: 'unsigned char * pByteShort'.
	self var: #pByteLong declareC: 'unsigned char * pByteLong'.
	self var: #pByteRes declareC: 'unsigned char * pByteRes'.
	self var: #shortLen declareC: 'int shortLen'.
	self var: #longLen declareC: 'int longLen'.
	self var: #carry declareC: 'int carry'.
	self var: #limitLong declareC: 'int limitLong'.
	self var: #limitShort declareC: 'int limitShort'.
	self var: #digit declareC: 'int digit'.
	self var: #ab declareC: 'int ab'.
	self var: #k declareC: 'int k'.
	(shortLen = 1 and: [(pByteShort at: 0)
			= 0])
		ifTrue: [^ 0].
	(longLen = 1 and: [(pByteLong at: 0)
			= 0])
		ifTrue: [^ 0].
	"prod starts out all zero"
	limitShort _ shortLen - 1.
	0 to: limitShort do: [:i | (digit _ pByteShort at: i) ~= 0
			ifTrue: 
				[k _ i.
				carry _ 0.
				"Loop invariant: 0<=carry<=0377, k=i+j-1 (ST)"
				"-> Loop invariant: 0<=carry<=0377, k=i+j (C) (?)"
				limitLong _ longLen - 1.
				0 to: limitLong do: 
					[:j | 
					ab _ (pByteLong at: j)
								* digit + carry + (pByteRes at: k).
					carry _ ab bitShift: -8.
					pByteRes at: k put: (ab bitAnd: 255).
					k _ k + 1].
				pByteRes at: k put: carry]].
	^ 0