color: aColor
	"Set the background color of this world."

	color = aColor ifFalse: [
		color _ aColor.
		self fullRepaintNeeded.
		"Propagate to view"
		self changed: #newColor].
