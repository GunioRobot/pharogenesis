sourceForm: srcForm destRect: dstRectangle
	"Set up a WarpBlt from the entire source Form to the given destination rectangle."
	| w h |
	sourceForm _ srcForm.
	sourceX _ sourceY _ 0.
	destX _ dstRectangle left.
	destY _ dstRectangle top.
	width _ dstRectangle width.
	height _ dstRectangle height.
	w _ srcForm width.
	h _ srcForm height.
	(w = width and:[h = height]) ifTrue:[
		"Don't need no stinking warp"
		warpQuad _ nil
	] ifFalse:[
		"Oh well ... "
		w _ 16384 * (w - 1).
		h _ 16384 * (h - 1).
		warpQuad _ Array
			with: 0@0 with: 0@h
			with: w@h with: w@0.
	].