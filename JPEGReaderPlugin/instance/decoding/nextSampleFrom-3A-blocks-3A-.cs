nextSampleFrom: aComponent blocks: aBlockArray
	| dx dy blockIndex sampleIndex sample curX sx sy |
	self var: #aComponent type: 'int *'.
	self var: #aBlockArray type: 'int **'.
	self inline: true.
	dx _ curX _ aComponent at: CurrentXIndex.
	dy _ aComponent at: CurrentYIndex.
	sx _ aComponent at: HScaleIndex.
	sy _ aComponent at: VScaleIndex.
	(sx = 0 and:[sy = 0]) ifFalse:[
		dx _ dx // sx.
		dy _ dy // sy.
	].
	blockIndex _ (dy bitShift: -3) * (aComponent at: BlockWidthIndex) + (dx bitShift: -3).
	sampleIndex _ ((dy bitAnd: 7) bitShift: 3) + (dx bitAnd: 7).
	sample _ (aBlockArray at: blockIndex) at: sampleIndex.
	curX _ curX + 1.
	curX < ((aComponent at: MCUWidthIndex) * 8) ifTrue:[
		aComponent at: CurrentXIndex put: curX.
	] ifFalse:[
		aComponent at: CurrentXIndex put: 0.
		aComponent at: CurrentYIndex put: (aComponent at: CurrentYIndex) + 1.
	].
	^ sample