sourceForm: srcForm destRect: dstRectangle
	"Set up a WarpBlt from the entire source Form to the given destination rectangle."

	| w h |
	sourceForm _ srcForm.
	sourceX _ sourceY _ 0.
	destX _ dstRectangle left.
	destY _ dstRectangle top.
	width _ dstRectangle width.
	height _ dstRectangle height.
	w _ 16384 * (srcForm width - 1).
	h _ 16384 * (srcForm height - 1).
	p1x _ 0.
	p2x _ 0.
	p3x _ w.
	p4x _ w.
	p1y _ 0.
	p2y _ h.
	p3y _ h.
	p4y _ 0.
	p1z _ p2z _ p3z _ p4z _ 16384.  "z-warp ignored for now"
