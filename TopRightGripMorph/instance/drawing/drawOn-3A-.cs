drawOn: aCanvas

	| dotBounds alphaCanvas windowBorderWidth dotBounds2 |

	windowBorderWidth _ SystemWindow borderWidth.
	bounds _ self bounds.
	alphaCanvas _ aCanvas asAlphaBlendingCanvas: 0.7.	
	"alphaCanvas
		frameRectangle: bounds color: Color blue."

	dotBounds _ (bounds insetBy: 1).
	dotBounds2 _ dotBounds left: (dotBounds right - windowBorderWidth).
	dotBounds2 _ dotBounds2 bottom: (dotBounds2 top + windowBorderWidth).
	alphaCanvas
		fillRectangle: dotBounds2
		color: self handleColor.
	
	dotBounds2 _ dotBounds right: (dotBounds right - windowBorderWidth).
	dotBounds2 _ dotBounds2 bottom: (dotBounds2 top + windowBorderWidth).
	alphaCanvas
		fillRectangle: dotBounds2
		color: self handleColor.

	dotBounds2 _ dotBounds2 left: (dotBounds2 left + 7).
	dotBounds2 _ dotBounds2 right: (dotBounds2 right - 7).
	alphaCanvas
		fillRectangle: dotBounds2
		color: self dotColor.

	dotBounds2 _ dotBounds left: (dotBounds right - windowBorderWidth).
	dotBounds2 _ dotBounds2 top: (dotBounds2 top + windowBorderWidth).
	alphaCanvas
		fillRectangle: dotBounds2
		color: self handleColor.

	dotBounds2 _ dotBounds2 top: (dotBounds2 top + 7).
	dotBounds2 _ dotBounds2 bottom: (dotBounds2 bottom - 7).
	alphaCanvas
		fillRectangle: dotBounds2
		color: self dotColor