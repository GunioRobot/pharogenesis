dynamicBlockSizeFor: lTree and: dTree using: blTree and: blFreq
	"Compute the length for the current block using dynamic huffman trees"
	| bits index extra treeBits freq |
	bits _ 3 "block type" + 5 "literal codes length" + 5 "distance codes length".

	"Compute the # of bits for sending the bit length tree"
	treeBits _ 4. "Max index for bit length tree"
	index _ MaxBitLengthCodes.
	[index >= 4] whileTrue:[
		(index = 4 or:[(blFreq at: (BitLengthOrder at: index)+1) > 0])
			ifTrue:[treeBits _ treeBits + (index * 3).
					index _ -1]
			ifFalse:[index _ index - 1]].

	"Compute the # of bits for sending the literal/distance tree.
	Note: The frequency are already stored in the blTree"
	0 to: 15 do:[:i| "First, the non-repeating values"
		freq _ blFreq at: i+1.
		freq > 0 ifTrue:[treeBits _ treeBits + (freq * (blTree bitLengthAt: i))]].
	"Now the repeating values"
	(Repeat3To6 to: Repeat11To138) with: #(2 3 7) do:[:i :addl|
		freq _ blFreq at: i+1.
		freq > 0 ifTrue:[
			treeBits _ treeBits + (freq * ((blTree bitLengthAt: i) + addl "addl bits"))]].
	VerboseLevel > 1 ifTrue:[
		Transcript show:'['; print: treeBits; show:' bits for dynamic tree]'].
	bits _ bits + treeBits.

	"Compute the size of the compressed block"
	0 to: NumLiterals do:[:i| "encoding of literals"
		freq _ literalFreq at: i+1.
		freq > 0 ifTrue:[bits _ bits + (freq * (lTree bitLengthAt: i))]].
	NumLiterals+1 to: lTree maxCode do:[:i| "encoding of match lengths"
		freq _ literalFreq at: i+1.
		extra _ ExtraLengthBits at: i-NumLiterals.
		freq > 0 ifTrue:[bits _ bits + (freq * ((lTree bitLengthAt: i) + extra))]].
	0 to: dTree maxCode do:[:i| "encoding of distances"
		freq _ distanceFreq at: i+1.
		extra _ ExtraDistanceBits at: i+1.
		freq > 0 ifTrue:[bits _ bits + (freq * ((dTree bitLengthAt: i) + extra))]].

	^bits