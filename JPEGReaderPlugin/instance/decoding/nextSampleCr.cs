nextSampleCr
	| dx dy blockIndex sampleIndex sample curX sx sy |
	self inline: true.
	dx _ curX _ crComponent at: CurrentXIndex.
	dy _ crComponent at: CurrentYIndex.
	sx _ crComponent at: HScaleIndex.
	sy _ crComponent at: VScaleIndex.
	(sx = 0 and:[sy = 0]) ifFalse:[
		dx _ dx // sx.
		dy _ dy // sy.
	].
	blockIndex _ (dy bitShift: -3) * (crComponent at: BlockWidthIndex) + (dx bitShift: -3).
	sampleIndex _ ((dy bitAnd: 7) bitShift: 3) + (dx bitAnd: 7).
	sample _ (crBlocks at: blockIndex) at: sampleIndex.
	curX _ curX + 1.
	curX < ((crComponent at: MCUWidthIndex) * 8) ifTrue:[
		crComponent at: CurrentXIndex put: curX.
	] ifFalse:[
		crComponent at: CurrentXIndex put: 0.
		crComponent at: CurrentYIndex put: (crComponent at: CurrentYIndex) + 1.
	].
	^ sample