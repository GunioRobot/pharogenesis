adjustAALevel

		"NOTE: 	This method is (hopefully) obsolete due to unrolling 
				the fill loops to deal with full pixels."

	"Adjust the span buffers values by the appropriate color offset for anti-aliasing.
	We do this by replicating the top bits of each color in the lower bits. The idea is that we can scale each color value uniquely from 0 to 255 and thus fill the entire range of colors."
	| adjustShift adjustMask x0 x1 pixelValue |
	self inline: false.
	adjustShift _ 8 - self aaColorShiftGet.
	adjustMask _ self aaColorMaskGet bitInvert32.
	x0 _ self spanStartGet >> self aaShiftGet.
	x1 _ self spanEndGet >> self aaShiftGet.
	[x0 < x1] whileTrue:[
		pixelValue _ spanBuffer at: x0.
		spanBuffer at: x0 put: (pixelValue bitOr: (pixelValue >> adjustShift bitAnd: adjustMask)).
		x0 _ x0 + 1].