anyBitOfBytes: aBytesOop from: start to: stopArg 
	"Argument has to be aBytesOop!"
	"Tests for any magnitude bits in the interval from start to stopArg."
	| magnitude rightShift leftShift stop firstByteIx lastByteIx |
	self
		debugCode: [self msg: 'anyBitOfBytes: aBytesOop from: start to: stopArg'].
	start < 1 | (stopArg < 1)
		ifTrue: [^ interpreterProxy primitiveFail].
	magnitude _ aBytesOop.
	stop _ stopArg
				min: (self highBitOfBytes: magnitude).
	start > stop
		ifTrue: [^ false].
	firstByteIx _ start - 1 // 8 + 1.
	lastByteIx _ stop - 1 // 8 + 1.
	rightShift _ 0 - (start - 1 \\ 8).
	leftShift _ 7 - (stop - 1 \\ 8).
	firstByteIx = lastByteIx
		ifTrue: [| digit mask | 
			mask _ (255 bitShift: 0 - rightShift)
						bitAnd: (255 bitShift: 0 - leftShift).
			digit _ self digitOfBytes: magnitude at: firstByteIx.
			^ (digit bitAnd: mask)
				~= 0].
	((self digitOfBytes: magnitude at: firstByteIx)
			bitShift: rightShift)
			~= 0
		ifTrue: [^ true].
	firstByteIx + 1
		to: lastByteIx - 1
		do: [:ix | (self digitOfBytes: magnitude at: ix)
					~= 0
				ifTrue: [^ true]].
	(((self digitOfBytes: magnitude at: lastByteIx)
			bitShift: leftShift)
			bitAnd: 255)
			~= 0
		ifTrue: [^ true].
	^ false