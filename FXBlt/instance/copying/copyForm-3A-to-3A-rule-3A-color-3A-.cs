copyForm: srcForm to: destPt rule: rule color: color
	sourceForm _ srcForm.
	halftoneForm _ color.
	combinationRule _ rule.
	destX _ destPt x + sourceForm offset x.
	destY _ destPt y + sourceForm offset y.
	sourceX _ 0.
	sourceY _ 0.
	width _ sourceForm width.
	height _ sourceForm height.
	self copyBits