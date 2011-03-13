copyFrom: sourceRectangle in: srcForm to: destPt
	| sourceOrigin |
	sourceForm _ srcForm.
	halftoneForm _ nil.
	combinationRule _ 3.  "store"
	destX _ destPt x.
	destY _ destPt y.
	sourceOrigin _ sourceRectangle origin.
	sourceX _ sourceOrigin x.
	sourceY _ sourceOrigin y.
	width _ sourceRectangle width.
	height _ sourceRectangle height.
	self copyBits