copyPixelsRGBA: y
	"Handle non-interlaced RGBA color modes (colorType = 6)"

	| i pixel b |
	b _ BitBlt current bitPokerToForm: form.
	bitsPerChannel = 8
		ifTrue: [
			0 to: width-1 do: [ :x |
				i _ (x << 2) + 1.
				pixel _ ((thisScanline at: i+3)<<24)
					+ ((thisScanline at: i)<<16)
					+ ((thisScanline at: i+1)<<8)
					+ ((thisScanline at: i+2)).
				b pixelAt: x@y put: pixel.
				]
			]
		ifFalse: [
			0 to: width-1 do: [ :x |
				i _ (x << 3) +1.
				pixel _ ((thisScanline at: i+6)<<24)
					+  ((thisScanline at: i)<<16)
					+ ((thisScanline at: i+2)<<8)
					+ ((thisScanline at: i+4)).
				b pixelAt: x@y put: pixel
				]
			]
