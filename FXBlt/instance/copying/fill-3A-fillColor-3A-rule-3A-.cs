fill: destRect fillColor: grayForm rule: rule
	"Fill with a Color, not a Form. 6/18/96 tk"
	sourceForm _ nil.
	self fillColor: grayForm.		"sets halftoneForm"
	combinationRule _ rule.
	destX _ destRect left.
	destY _ destRect top.
	sourceX _ 0.
	sourceY _ 0.
	width _ destRect width.
	height _ destRect height.
	self copyBits