nextSampleCb
	| dx dy blockIndex sampleIndex sample curX sx sy |
	self inline: true.
	dx _ curX _ cbComponent at: CurrentXIndex.
	dy _ cbComponent at: CurrentYIndex.
	sx _ cbComponent at: HScaleIndex.
	sy _ cbComponent at: VScaleIndex.
	(sx = 0 and:[sy = 0]) ifFalse:[
		dx _ dx // sx.
		dy _ dy // sy.
	].
	blockIndex _ (dy bitShift: -3) * (cbComponent at: BlockWidthIndex) + (dx bitShift: -3).
	sampleIndex _ ((dy bitAnd: 7) bitShift: 3) + (dx bitAnd: 7).
	sample _ (cbBlocks at: blockIndex) at: sampleIndex.
	curX _ curX + 1.
	curX < ((cbComponent at: MCUWidthIndex) * 8) ifTrue:[
		cbComponent at: CurrentXIndex put: curX.
	] ifFalse:[
		cbComponent at: CurrentXIndex put: 0.
		cbComponent at: CurrentYIndex put: (cbComponent at: CurrentYIndex) + 1.
	].
	^ sample