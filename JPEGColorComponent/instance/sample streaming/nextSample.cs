nextSample

	| dx dy blockIndex sampleIndex sample |
	dx _ currentX // hSampleFactor.
	dy _ currentY // vSampleFactor.
	blockIndex _ dy // dctSize * widthInBlocks + (dx // dctSize) + 1.
	sampleIndex _ dy \\ dctSize * dctSize + (dx \\ dctSize) + 1.
	sample _ (mcuBlocks at: blockIndex) at: sampleIndex.
	currentX _ currentX + 1.
	currentX < (mcuWidth * dctSize)
		ifFalse:
			[currentX _ 0.
			currentY _ currentY + 1].
	^ sample