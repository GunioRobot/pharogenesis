updateTransform: aTransform andClipRect: aClipRect
	"sets the given transform and clip rectangle, if they aren't already the ones being used"
	aTransform = lastTransform ifFalse: [
		self setTransform: aTransform.
		lastTransform _ aTransform ].

	aClipRect = lastClipRect ifFalse: [
		self setClipRect: aClipRect.
		lastClipRect _ aClipRect. ].