constrainFrame: aRectangle
	"Constrain aRectangle, to the minimum and maximum size
	for this window"

   | adjustmentForLabel |
   adjustmentForLabel := 0 @ (labelFrame height  - labelFrame borderWidth).
	^ aRectangle origin extent:
		((aRectangle extent max: minimumSize + adjustmentForLabel)
		      min: maximumSize + adjustmentForLabel).