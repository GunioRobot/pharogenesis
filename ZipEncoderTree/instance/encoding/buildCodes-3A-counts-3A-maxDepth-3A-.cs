buildCodes: nodeList counts: blCounts maxDepth: depth
	"Build the codes for all nodes"
	| nextCode code node length |
	nextCode _ WordArray new: depth+1.
	code _ 0.
	1 to: depth do:[:bits|
		code _ (code + (blCounts at: bits)) << 1.
		nextCode at: bits+1 put: code].
	self assert:[(code + (blCounts at: depth+1) - 1) = (1 << depth - 1)].
	0 to: maxCode do:[:n|
		node _ nodeList at: n+1.
		length _ node bitLength.
		length = 0 ifFalse:[
			code _ nextCode at: length+1.
			node code: (self reverseBits: code length: length).
			nextCode at: length+1 put: code+1.
		].
	].