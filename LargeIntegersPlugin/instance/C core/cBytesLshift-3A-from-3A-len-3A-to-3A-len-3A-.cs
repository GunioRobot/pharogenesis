cBytesLshift: shiftCount from: pFrom len: lenFrom to: pTo len: lenTo 
	"C indexed!"
	| byteShift bitShift carry rShift mask limit digit lastIx |
	self returnTypeC: 'int'.
	self var: #pTo declareC: 'unsigned char * pTo'.
	self var: #pFrom declareC: 'unsigned char * pFrom'.
	self var: #lenFrom declareC: 'int lenFrom'.
	self var: #lenTo declareC: 'int lenTo'.
	byteShift _ shiftCount // 8.
	bitShift _ shiftCount \\ 8.
	bitShift = 0 ifTrue: ["Fast version for byte-aligned shifts"
		"C indexed!"
		^ self
			cBytesReplace: pTo
			from: byteShift
			to: lenTo - 1
			with: pFrom
			startingAt: 0].
	carry _ 0.
	rShift _ bitShift - 8.
	mask _ 255 bitShift: 0 - bitShift.
	limit _ byteShift - 1.
	0 to: limit do: [:i | pTo at: i put: 0].
	limit _ lenTo - byteShift - 2.
	self sqAssert: limit < lenFrom.
	0 to: limit do: 
		[:i | 
		digit _ pFrom at: i.
		pTo at: i + byteShift put: (((digit bitAnd: mask)
				bitShift: bitShift)
				bitOr: carry).
		carry _ digit bitShift: rShift].
	lastIx _ limit + 1.
	lastIx > (lenFrom - 1)
		ifTrue: [digit _ 0]
		ifFalse: [digit _ pFrom at: lastIx].
	pTo at: lastIx + byteShift put: (((digit bitAnd: mask)
			bitShift: bitShift)
			bitOr: carry).
	carry _ digit bitShift: rShift.
	self sqAssert: carry = 0