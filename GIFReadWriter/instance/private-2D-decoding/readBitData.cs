readBitData
	"using modified Lempel-Ziv Welch algorithm."

	| outCodes outCount bitMask initCodeSize code curCode oldCode inCode finChar i bytes f c packedBits hasLocalColor localColorSize maxOutCodes |

	maxOutCodes _ 4096.
	offset := self readWord@self readWord. "Image Left@Image Top"
	width _ self readWord.
	height _ self readWord.

	"---
	Local Color Table Flag        1 Bit
	Interlace Flag                1 Bit
	Sort Flag                     1 Bit
	Reserved                      2 Bits
	Size of Local Color Table     3 Bits
	----"
	packedBits _ self next.
	interlace _ (packedBits bitAnd: 16r40) ~= 0.
	hasLocalColor _ (packedBits bitAnd: 16r80) ~= 0.
	localColorSize _ 1 bitShift: ((packedBits bitAnd: 16r7) + 1).
	hasLocalColor ifTrue: [localColorTable _ self readColorTable: localColorSize].

	pass _ 0.
	xpos _ 0.
	ypos _ 0.
	rowByteSize _ ((width + 3) // 4) * 4.
	remainBitCount _ 0.
	bufByte _ 0.
	bufStream _ ReadStream on: ByteArray new.

	outCodes _ ByteArray new: maxOutCodes + 1.
	outCount _ 0.
	bitMask _ (1 bitShift: bitsPerPixel) - 1.
	prefixTable _ Array new: 4096.
	suffixTable _ Array new: 4096.

	initCodeSize _ self next.

	self setParameters: initCodeSize.
	bitsPerPixel > 8 ifTrue: [^self error: 'never heard of a GIF that deep'].
	bytes _ ByteArray new: rowByteSize * height.
	[(code _ self readCode) = eoiCode] whileFalse:
		[code = clearCode
			ifTrue:
				[self setParameters: initCodeSize.
				curCode _ oldCode _ code _ self readCode.
				finChar _ curCode bitAnd: bitMask.
				"Horrible hack to avoid running off the end of the bitmap.  Seems to cure problem reading some gifs!? tk 6/24/97 20:16"
				xpos = 0 ifTrue: [
						ypos < height ifTrue: [
							bytes at: (ypos * rowByteSize) + xpos + 1 put: finChar]]
					ifFalse: [bytes at: (ypos * rowByteSize) + xpos + 1 put: finChar].
				self updatePixelPosition]
			ifFalse:
				[curCode _ inCode _ code.
				curCode >= freeCode ifTrue:
					[curCode _ oldCode.
					outCodes at: (outCount _ outCount + 1) put: finChar].
				[curCode > bitMask] whileTrue:
					[outCount > maxOutCodes
						ifTrue: [^self error: 'corrupt GIF file (OutCount)'].
					outCodes at: (outCount _ outCount + 1)
						put: (suffixTable at: curCode + 1).
					curCode _ prefixTable at: curCode + 1].
				finChar _ curCode bitAnd: bitMask.
				outCodes at: (outCount _ outCount + 1) put: finChar.
				i _ outCount.
				[i > 0] whileTrue:
					["self writePixel: (outCodes at: i) to: bits"
					bytes at: (ypos * rowByteSize) + xpos + 1 put: (outCodes at: i).
					self updatePixelPosition.
					i _ i - 1].
				outCount _ 0.
				prefixTable at: freeCode + 1 put: oldCode.
				suffixTable at: freeCode + 1 put: finChar.
				oldCode _ inCode.
				freeCode _ freeCode + 1.
				self checkCodeSize]].
	prefixTable _ suffixTable _ nil.

	f _ ColorForm extent: width@height depth: 8.
	f bits copyFromByteArray: bytes.
	"Squeak can handle depths 1, 2, 4, and 8"
	bitsPerPixel > 4 ifTrue: [^ f].
	"reduce depth to save space"
	c _ ColorForm extent: width@height
		depth: (bitsPerPixel = 3 ifTrue: [4] ifFalse: [bitsPerPixel]).
	f displayOn: c.
	^ c
