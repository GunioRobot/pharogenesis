unpackBits: bits depthTo8From: depth with: width height: height pad: pad
	"Unpack bits of depth 1, 2, or 4 image to it of depth 8 image."

	| bitMask pixelInByte bitsWidth upBitsWidth stopWidth
	 trailingSize upBits bitIndex upBitIndex val |
	(#(1 2 4) includes: depth)
		ifFalse: [^self error: 'depth must be 1, 2, or 4'].
	(#(8 16 32) includes: pad)
		ifFalse: [^self error: 'pad must be 8, 16, or 32'].
	bitMask _ (1 bitShift: depth) - 1.
	pixelInByte _ 8 / depth.
	bitsWidth _ width * depth + pad - 1 // pad * (pad / 8).
	upBitsWidth _ width * 8 + pad - 1 // pad * (pad / 8).
	stopWidth _ width * depth + 7 // 8.
	trailingSize _ width - (stopWidth - 1 * pixelInByte).
	upBits _ ByteArray new: upBitsWidth * height.
	1 to: height do: [:i |
		bitIndex _ i - 1 * bitsWidth.
		upBitIndex _ i - 1 * upBitsWidth.
		1 to: stopWidth - 1 do: [:j |
			val _ bits byteAt: (bitIndex _ bitIndex + 1).
			upBitIndex _ upBitIndex + pixelInByte.
			1 to: pixelInByte do: [:k |
				upBits at: (upBitIndex - k + 1) put: (val
bitAnd: bitMask).
				val _ val bitShift: depth negated]].
		val _ (bits byteAt: (bitIndex _ bitIndex + 1))
				bitShift: depth negated * (pixelInByte -
trailingSize).
		upBitIndex _ upBitIndex + trailingSize.
		1 to: trailingSize do: [:k |
			upBits at: (upBitIndex - k + 1) put: (val bitAnd:
bitMask).
			val _ val bitShift: depth negated]].
	^ upBits
