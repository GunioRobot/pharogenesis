fillColorSpanAA: pixelValue32 x0: leftX x1: rightX
	"This is the inner loop for solid color fills with anti-aliasing.
	This loop has been unrolled for speed and quality into three parts:
		a) copy all pixels that fall into the first full pixel.
		b) copy aaLevel pixels between the first and the last full pixel
		c) copy all pixels that fall in the last full pixel"
	| colorMask baseShift x idx firstPixel lastPixel aaLevel pv32 |
	self inline: false. "Not now -- maybe later"
	"Compute the pixel boundaries."
	firstPixel _ self aaFirstPixelFrom: leftX to: rightX.
	lastPixel _ self aaLastPixelFrom: leftX to: rightX.
	aaLevel _ self aaLevelGet.
	baseShift _ self aaShiftGet.
	x _ leftX.

	"Part a: Deal with the first n sub-pixels"
	x < firstPixel ifTrue:[
		pv32 _ (pixelValue32 bitAnd: self aaColorMaskGet) >> self aaColorShiftGet.
		[x < firstPixel] whileTrue:[
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + pv32.
			x _ x + 1.
		].
	].

	"Part b: Deal with the full pixels"
	x < lastPixel ifTrue:[
		colorMask _ (self aaColorMaskGet >> self aaShiftGet) bitOr: 16rF0F0F0F0.
		pv32 _ (pixelValue32 bitAnd: colorMask) >> self aaShiftGet.
		[x < lastPixel] whileTrue:[
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + pv32.
			x _ x + aaLevel.
		].
	].

	"Part c: Deal with the last n sub-pixels"
	x < rightX ifTrue:[
		pv32 _ (pixelValue32 bitAnd: self aaColorMaskGet) >> self aaColorShiftGet.
		[x < rightX] whileTrue:[
			idx _ x >> baseShift.
			spanBuffer at: idx put: (spanBuffer at: idx) + pv32.
			x _ x + 1.
		].
	].