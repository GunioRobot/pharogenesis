clearSpanBuffer
	"Clear the current span buffer.
	The span buffer is only cleared in the area that has been used by the previous scan line."
	| x0 x1 |
	self inline: false.
	x0 _ self spanStartGet >> self aaShiftGet.
	x1 _ self spanEndGet >> self aaShiftGet + 1.
	x0 < 0 ifTrue:[x0 _ 0].
	x1 > self spanSizeGet ifTrue:[x1 _ self spanSizeGet].
	[x0 < x1] whileTrue:[
		spanBuffer at: x0 put: 0.
		x0 _ x0 + 1].
	self spanStartPut: self spanSizeGet.
	self spanEndPut: 0.