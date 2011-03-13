copyForm: srcForm to: destPt rule: rule fillColor: color
	sourceForm _ srcForm.
	self fillColor: color.	"sets halftoneForm"
	combinationRule _ rule.
	destX _ destPt x + sourceForm offset x.
	destY _ destPt y + sourceForm offset y.
	sourceX _ 0.
	sourceY _ 0.
	width _ sourceForm width.
	height _ sourceForm height.
	self copyBits