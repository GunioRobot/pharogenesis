currentColor: aColor
	"Force me to select the closest color to this"

	prevColor _ currentColor.
	locOfCurrent _ nil.
	^ currentColor _ aColor
	"We don't know where to put the marker"