shapeFill: aColor interiorPoint: interiorPoint
	"Identify the shape (region of identical color) at interiorPoint,
	and then fill that shape with the new color, aColor
	9/19/96 sw: modified di's original method such that it returns the bwForm, for potential use by the caller"

	| bwForm map interiorColor |
	depth = 1 ifTrue:
		[^ self shapeFill: aColor
			seedBlock: [:form | form pixelValueAt: interiorPoint put: 1]].

	"First map this form into a B/W form with 0's in the interior region."
	interiorColor _ Color colorFromPixelValue:
		(self pixelValueAt: interiorPoint) depth: depth.
	bwForm _ self makeBWForm: interiorColor.
	bwForm reverse.  "Make interior region be 0's"

	"Now fill the interior region and return that shape"
	bwForm _ bwForm findShapeAroundSeedBlock:
					[:form | form pixelValueAt: interiorPoint put: 1].

	"Finally use that shape as a mask to flood the region with color"
	self fillShape: bwForm fillColor: aColor.
	^ bwForm