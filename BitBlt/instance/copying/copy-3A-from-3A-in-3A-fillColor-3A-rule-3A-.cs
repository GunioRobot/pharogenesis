copy: destRectangle from: sourcePt in: srcForm fillColor: hf rule: rule
	"Specify a Color to fill, not a Form. 6/18/96 tk"  
	| destOrigin |
	sourceForm _ srcForm.
	self fillColor: hf.	"sets halftoneForm"
	combinationRule _ rule.
	destOrigin _ destRectangle origin.
	destX _ destOrigin x.
	destY _ destOrigin y.
	sourceX _ sourcePt x.
	sourceY _ sourcePt y.
	width _ destRectangle width.
	height _ destRectangle height.
	^ self copyBits