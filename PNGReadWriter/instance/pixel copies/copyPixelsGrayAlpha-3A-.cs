copyPixelsGrayAlpha: y
	"Handle non-interlaced grayscale with alpha color mode (colorType = 4)"

	| i pixel gray b |
	b _ BitBlt current bitPokerToForm: form.
	bitsPerChannel = 8
		ifTrue: [
			0 to: width-1 do: [ :x |
				i _ (x << 1) + 1.
				gray _ thisScanline at: i.
				pixel _ ((thisScanline at: i+1)<<24) + (gray<<16) + (gray<<8) + gray.
				b pixelAt: x@y put: pixel.
				]
			]
		ifFalse: [
			0 to: width-1 do: [ :x |
				i _ (x << 2) + 1.
				gray _ thisScanline at: i.
				pixel _ ((thisScanline at: i+2)<<24) + (gray<<16) + (gray<<8) + gray.
				b pixelAt: x@y put: pixel.
				]
			]
