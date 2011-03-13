progressColor: aColor
	progressColor = aColor
		ifFalse:
			[progressColor _ aColor.
			self changed]