cCoreBytesRshiftCount: count n: n m: m f: f bytes: b from: pFrom len: fromLen to: pTo len: toLen 
	| x digit |
	self var: #pTo declareC: 'unsigned char * pTo'.
	self var: #pFrom declareC: 'unsigned char * pFrom'.
	self sqAssert: b < fromLen.
	x _ (pFrom at: b)
				bitShift: n.
	self sqAssert: count - 1 < fromLen.
	b + 1 to: count - 1 do: 
		[:j | 
		digit _ pFrom at: j.
		pTo at: j - b - 1 put: (((digit bitAnd: m)
				bitShift: f)
				bitOr: x).
		"Avoid values > 8 bits"
		x _ digit bitShift: n].
	count = fromLen
				ifTrue: [digit _ 0]
				ifFalse: [digit _ pFrom at: count].
	pTo at: count - b - 1 put: (((digit bitAnd: m)
			bitShift: f)
			bitOr: x)