color: aColor
	"Set the background color of this world."

	super color: aColor.
	self fullRepaintNeeded.
	"Propagate to view"
	self changed: #newColor.
