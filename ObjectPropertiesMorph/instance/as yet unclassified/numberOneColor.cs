numberOneColor

	myTarget fillStyle isGradientFill ifFalse: [^myTarget color].
	^myTarget fillStyle colorRamp first value
