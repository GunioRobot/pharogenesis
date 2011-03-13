copyPixelsGray: y 
	"Handle non-interlaced grayscale color mode (colorType = 0)"
	| blitter pixPerByte mask shifts pixelNumber rawByte pixel transparentIndex |
	blitter := BitBlt current bitPokerToForm: form.
	transparentIndex := form colors size.
	bitsPerChannel = 16 
		ifTrue: 
			[ 0 
				to: width - 1
				do: 
					[ :x | 
					blitter 
						pixelAt: x @ y
						put: 255 - (thisScanline at: (x << 1) + 1) ].
			^ self ]
		ifFalse: 
			[ bitsPerChannel = 8 ifTrue: 
				[ 1 
					to: width
					do: 
						[ :x | 
						blitter 
							pixelAt: (x - 1) @ y
							put: (thisScanline at: x) ].
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
			pixelNumber := 0.
			0 
				to: width - 1
				do: 
					[ :x | 
					rawByte := thisScanline at: pixelNumber // pixPerByte + 1.
					pixel := rawByte >> (shifts at: pixelNumber \\ pixPerByte + 1) bitAnd: mask.
					pixel = transparentPixelValue ifTrue: [ pixel := transparentIndex ].
					blitter 
						pixelAt: x @ y
						put: pixel.
					pixelNumber := pixelNumber + 1 ] ]