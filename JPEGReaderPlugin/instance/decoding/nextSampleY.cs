nextSampleY
	| dx dy blockIndex sampleIndex sample curX sx sy |
	self inline: true.
	dx _ curX _ yComponent at: CurrentXIndex.
	dy _ yComponent at: CurrentYIndex.
	sx _ yComponent at: HScaleIndex.
	sy _ yComponent at: VScaleIndex.
	(sx = 0 and:[sy = 0]) ifFalse:[
		dx _ dx // sx.
		dy _ dy // sy.
	].
	blockIndex _ (dy bitShift: -3) * (yComponent at: BlockWidthIndex) + (dx bitShift: -3).
	sampleIndex _ ((dy bitAnd: 7) bitShift: 3) + (dx bitAnd: 7).
	sample _ (yBlocks at: blockIndex) at: sampleIndex.
	curX _ curX + 1.
	curX < ((yComponent at: MCUWidthIndex) * 8) ifTrue:[
		yComponent at: CurrentXIndex put: curX.
	] ifFalse:[
		yComponent at: CurrentXIndex put: 0.
		yComponent at: CurrentYIndex put: (yComponent at: CurrentYIndex) + 1.
	].
	^ sample