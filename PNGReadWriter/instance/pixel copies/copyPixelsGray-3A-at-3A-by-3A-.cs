copyPixelsGray: y at: startX by: incX
	"Handle interlaced grayscale color mode (colorType = 0)"

	| b offset bits w pixel mask blitter pixelNumber pixPerByte rawByte
shifts |
	bitsPerChannel = 16
		ifTrue: [
			b _ BitBlt current bitPokerToForm: form.
			startX to: width-1 by: incX do: [ :x |
				b pixelAt: x@y put: 255 - (thisScanline at: (x//incX<<1)+1).
				].
			^ self
			].
	offset _ y*rowSize+1.
	bits _ form bits.
	bitsPerChannel = 8 ifTrue: [
		startX to: width-1 by: incX do: [ :x |
			w _ offset + (x>>2).
			b _ 3- (x \\ 4) * 8.
			pixel _ (thisScanline at: x // incX + 1)<<b.
			mask _ (255<<b) bitInvert32.
			bits at: w put: (((bits at: w) bitAnd: mask) bitOr: pixel)
		].
		^ self
	].
	bitsPerChannel = 1 ifTrue: [
		pixPerByte _ 8.
		mask _ 1.
		shifts _ #(7 6 5 4 3 2 1 0).
	].
	bitsPerChannel = 2 ifTrue: [
		pixPerByte _ 4.
		mask _ 3.
		shifts _ #(6 4 2 0).
	].
	bitsPerChannel = 4 ifTrue: [
		pixPerByte _ 2.
		mask _ 15.
		shifts _ #(4 0).
	].

	blitter _ BitBlt current bitPokerToForm: form.
	pixelNumber _ 0.
	startX to: width-1 by: incX do: [ :x |
		rawByte _ thisScanline at: (pixelNumber // pixPerByte) + 1.
		pixel _ (rawByte >> (shifts at: (pixelNumber \\ pixPerByte) + 1)) bitAnd: mask.
		blitter pixelAt: (x@y) put: pixel.
		pixelNumber _ pixelNumber + 1.
	].
