sendLiteralTree: lTree distanceTree: dTree using: blTree bitLengths: bits
	"Send all the trees needed for dynamic huffman tree encoding"
	| lastValue lastCount value |
	encoder nextBits: 5 put: (lTree maxCode - 256).
	encoder nextBits: 5 put: (dTree maxCode).
	self sendBitLengthTree: blTree.
	bits size = 0 ifTrue:[^self].
	lastValue _ bits at: 1.
	lastCount _ 1.
	2 to: bits size do:[:i|
		value _ bits at: i.
		value = lastValue 
			ifTrue:[lastCount _ lastCount + 1]
			ifFalse:[self sendBitLength: lastValue repeatCount: lastCount tree: blTree.
					lastValue _ value.
					lastCount _ 1]].
	self sendBitLength: lastValue repeatCount: lastCount tree: blTree.