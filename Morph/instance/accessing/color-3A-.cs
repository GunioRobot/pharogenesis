color: aColor

	color = aColor ifFalse: [
		color _ aColor.
		self changed].
