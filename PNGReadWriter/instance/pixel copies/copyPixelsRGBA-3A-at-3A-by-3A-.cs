copyPixelsRGBA: y at: startX by: incX
	"Handle interlaced RGBA color modes (colorType = 6)"

	| i pixel b |
	b _ BitBlt current bitPokerToForm: form.
	bitsPerChannel = 8
		ifTrue: [
			startX to: width-1 by: incX do: [ :x |
				i _ (x // incX << 2) + 1.
				pixel _ ((thisScanline at: i+3)<<24)
					+ ((thisScanline at: i)<<16)
					+ ((thisScanline at: i+1)<<8)
					+ ((thisScanline at: i+2)).
				b pixelAt: x@y put: pixel.
				]
			]
		ifFalse: [
			startX to: width-1 by: incX do: [ :x |
				i _ (x // incX << 3) +1.
				pixel _ ((thisScanline at: i+6)<<24)
					+  ((thisScanline at: i)<<16)
					+ ((thisScanline at: i+2)<<8)
					+ ((thisScanline at: i+4)).
				b pixelAt: x@y put: pixel
				]
			]
