constrainFrame: aRectangle
	"Constrain aRectangle, to the minimum and maximum size
	for this window"

	^ aRectangle origin extent:
		((aRectangle extent max: minimumSize) min: maximumSize)