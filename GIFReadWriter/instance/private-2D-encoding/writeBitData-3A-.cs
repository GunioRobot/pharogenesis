writeBitData: bits
	"using modified Lempel-Ziv Welch algorithm."

	| maxBits maxMaxCode tSize initCodeSize ent tShift fCode pixel index disp nomatch |
	pass _ 0.
	xpos _ 0.
	ypos _ 0.
	rowByteSize _ width * 8 + 31 // 32 * 4.
	remainBitCount _ 0.
	bufByte _ 0.
	bufStream _ WriteStream on: (ByteArray new: 256).

	maxBits _ 12.
	maxMaxCode _ 1 bitShift: maxBits.
	tSize _ 5003.
	prefixTable _ Array new: tSize.
	suffixTable _ Array new: tSize.

	initCodeSize _ bitsPerPixel <= 1 ifTrue: [2] ifFalse: [bitsPerPixel].
	self nextPut: initCodeSize.
	self setParameters: initCodeSize.

	tShift _ 0.
	fCode _ tSize.
	[fCode < 65536] whileTrue:
		[tShift _ tShift + 1.
		fCode _ fCode * 2].
	tShift _ 8 - tShift.
	1 to: tSize do: [:i | suffixTable at: i put: -1].

	self writeCodeAndCheckCodeSize: clearCode.
	ent _ self readPixelFrom: bits.
	[(pixel _ self readPixelFrom: bits) == nil] whileFalse:
		[
		fCode _ (pixel bitShift: maxBits) + ent.
		index _ ((pixel bitShift: tShift) bitXor: ent) + 1.
		(suffixTable at: index) = fCode
			ifTrue: [ent _ prefixTable at: index]
			ifFalse:
				[nomatch _ true.
				(suffixTable at: index) >= 0
					ifTrue:
						[disp _ tSize - index + 1.
						index = 1 ifTrue: [disp _ 1].
						"probe"
						[(index _ index - disp) < 1 ifTrue: [index _ index + tSize].
						(suffixTable at: index) = fCode
							ifTrue:
								[ent _ prefixTable at: index.
								nomatch _ false.
								"continue whileFalse:"].
						nomatch and: [(suffixTable at: index) > 0]]
							whileTrue: ["probe"]].
				"nomatch"
				nomatch ifTrue:
					[self writeCodeAndCheckCodeSize: ent.
					ent _ pixel.
					freeCode < maxMaxCode
						ifTrue:
							[prefixTable at: index put: freeCode.
							suffixTable at: index put: fCode.
							freeCode _ freeCode + 1]
						ifFalse:
							[self writeCodeAndCheckCodeSize: clearCode.
							1 to: tSize do: [:i | suffixTable at: i put: -1].
							self setParameters: initCodeSize]]]].
	prefixTable _ suffixTable _ nil.
	self writeCodeAndCheckCodeSize: ent.
	self writeCodeAndCheckCodeSize: eoiCode.
	self flushCode.

	self nextPut: 0.	"zero-length packet"
