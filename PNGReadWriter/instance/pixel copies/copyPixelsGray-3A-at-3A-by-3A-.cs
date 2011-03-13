copyPixelsGray: y at: startX by: incX 
	"Handle interlaced grayscale color mode (colorType = 0)"
	| b offset bits w pixel mask blitter pixelNumber pixPerByte rawByte shifts |
	bitsPerChannel = 16 ifTrue: 
		[ b := BitBlt current bitPokerToForm: form.
		startX 
			to: width - 1
			by: incX
			do: 
				[ :x | 
				b 
					pixelAt: x @ y
					put: 255 - (thisScanline at: (x // incX << 1) + 1) ].
		^ self ].
	offset := y * rowSize + 1.
	bits := form bits.
	bitsPerChannel = 8 ifTrue: 
		[ startX 
			to: width - 1
			by: incX
			do: 
				[ :x | 
				w := offset + (x >> 2).
				b := (3 - (x \\ 4)) * 8.
				pixel := (thisScanline at: x // incX + 1) << b.
				mask := (255 << b) bitInvert32.
				bits 
					at: w
					put: (((bits at: w) bitAnd: mask) bitOr: pixel) ].
		^ self ].
	bitsPerChannel = 1 ifTrue: 
		[ pixPerByte := 8.
		mask := 1.
		shifts := #(7 6 5 4 3 2 1 0 ) ].
	bitsPerChannel = 2 ifTrue: 
		[ pixPerByte := 4.
		mask := 3.
		shifts := #(6 4 2 0 ) ].
	bitsPerChannel = 4 ifTrue: 
		[ pixPerByte := 2.
		mask := 15.
		shifts := #(4 0 ) ].
	blitter := BitBlt current bitPokerToForm: form.
	pixelNumber := 0.
	startX 
		to: width - 1
		by: incX
		do: 
			[ :x | 
			rawByte := thisScanline at: pixelNumber // pixPerByte + 1.
			pixel := rawByte >> (shifts at: pixelNumber \\ pixPerByte + 1) bitAnd: mask.
			blitter 
				pixelAt: x @ y
				put: pixel.
			pixelNumber := pixelNumber + 1 ]