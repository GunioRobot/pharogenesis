copy: destRectangle from: sourcePt in: srcForm
	| destOrigin |
	sourceForm _ srcForm.
	halftoneForm _ nil.
	combinationRule _ 3.  "store"
	destOrigin _ destRectangle origin.
	destX _ destOrigin x.
	destY _ destOrigin y.
	sourceX _ sourcePt x.
	sourceY _ sourcePt y.
	width _ destRectangle width.
	height _ destRectangle height.
	self copyBits