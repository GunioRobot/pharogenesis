stringHash: aString initialHash: speciesHash
	| stringSize hash low |
	stringSize _ aString size.
	hash _ speciesHash bitAnd: 16rFFFFFFF.
	1 to: stringSize do: [:pos |
		hash _ hash + (aString at: pos) asInteger.
		"Begin hashMultiply"
		low _ hash bitAnd: 16383.
		hash _ (16r260D * low + ((16r260D * (hash bitShift: -14) + (16r0065 * low) bitAnd: 16383) * 16384)) bitAnd: 16r0FFFFFFF.
	].
	^ hash.
