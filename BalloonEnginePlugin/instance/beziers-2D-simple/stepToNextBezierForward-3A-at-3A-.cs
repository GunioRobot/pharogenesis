stepToNextBezierForward: updateData at: yValue
	"Incrementally step to the next scan line in the given bezier update data.
	Note: This method has been written so that inlining works, e.g.,
		not declaring updateData as 'int*' but casting it on every use."
	| minY lastX lastY fwDx fwDy |
	self inline: true.
	lastX _ (self cCoerce: updateData to: 'int*') at: GBUpdateX.
	lastY _ (self cCoerce: updateData to: 'int*') at: GBUpdateY.
	fwDx _ (self cCoerce: updateData to: 'int*') at: GBUpdateDX.
	fwDy _ (self cCoerce: updateData to: 'int*') at: GBUpdateDY.
	minY _ yValue * 256.
	"Step as long as we haven't yet reached minY and also
	as long as fwDy is greater than zero thus stepping down.
	Note: The test for fwDy should not be necessary in theory
		but is a good insurance in practice."
	[minY > lastY and:[fwDy >= 0]] whileTrue:[
		lastX _ lastX + ((fwDx + 16r8000) // 16r10000).
		lastY _ lastY + ((fwDy + 16r8000) // 16r10000).
		fwDx _ fwDx + ((self cCoerce: updateData to: 'int*') at: GBUpdateDDX).
		fwDy _ fwDy + ((self cCoerce: updateData to: 'int*') at: GBUpdateDDY).
	].
	(self cCoerce: updateData to: 'int*') at: GBUpdateX put: lastX.
	(self cCoerce: updateData to: 'int*') at: GBUpdateY put: lastY.
	(self cCoerce: updateData to: 'int*') at: GBUpdateDX put: fwDx.
	(self cCoerce: updateData to: 'int*') at: GBUpdateDY put: fwDy.
	^lastX // 256
