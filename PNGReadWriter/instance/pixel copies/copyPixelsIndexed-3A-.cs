copyPixelsIndexed: y
	"Handle non-interlaced indexed color mode (colorType = 3)"
	| blitter pixPerByte mask shifts pixelNumber rawByte pixel |
	blitter _ BitBlt current bitPokerToForm: form.
	bitsPerChannel = 8
		ifTrue:
			[1 to: width do: [:x | blitter pixelAt: x - 1 @ y put: (thisScanline at: x)].
			^ self].
	bitsPerChannel = 1
		ifTrue:
			[pixPerByte _ 8.
			mask _ 1.
			shifts _ #(7 6 5 4 3 2 1 0 )].
	bitsPerChannel = 2
		ifTrue:
			[pixPerByte _ 4.
			mask _ 3.
			shifts _ #(6 4 2 0 )].
	bitsPerChannel = 4
		ifTrue:
			[pixPerByte _ 2.
			mask _ 15.
			shifts _ #(4 0 )].
	pixelNumber _ 0.
	0 to: width - 1 do:
		[:x |
		rawByte _ thisScanline at: pixelNumber // pixPerByte + 1.
		pixel _ rawByte >> (shifts at: pixelNumber \\ pixPerByte + 1) bitAnd: mask.
		blitter pixelAt: x @ y put: pixel.
		pixelNumber _ pixelNumber + 1]