copyForm: srcForm to: destPt rule: rule colorMap: map
	sourceForm _ srcForm.
	halftoneForm _ nil.
	combinationRule _ rule.
	destX _ destPt x + sourceForm offset x.
	destY _ destPt y + sourceForm offset y.
	sourceX _ 0.
	sourceY _ 0.
	width _ sourceForm width.
	height _ sourceForm height.
	colorMap _ map.
	self copyBits