display: argString at: argPoint from: argMinVal to: argMaxVal during: argWorkBlock

	progressTitle _ argString.
	aPoint _ argPoint.
	minVal _ argMinVal.
	maxVal _ argMaxVal.
	workBlock _ argWorkBlock.
	^self signal