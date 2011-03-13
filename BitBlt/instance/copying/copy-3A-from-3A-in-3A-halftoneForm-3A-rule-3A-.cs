copy: destRectangle from: sourcePt in: srcForm halftoneForm: hf rule: rule 
	| destOrigin |
	sourceForm _ srcForm.
	self fillColor: hf.		"sets halftoneForm"
	combinationRule _ rule.
	destOrigin _ destRectangle origin.
	destX _ destOrigin x.
	destY _ destOrigin y.
	sourceX _ sourcePt x.
	sourceY _ sourcePt y.
	width _ destRectangle width.
	height _ destRectangle height.
	self copyBits