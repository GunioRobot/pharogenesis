fullDrawOn: aCanvas
	"Overridden to clip submorph drawing to my bounds."

	| clippingCanvas  |
	(aCanvas isVisible: self bounds) ifFalse: [^ self].
	self borderWidth. "assure it's set, before it's blithely used by display code.  This is needed somewhere like here for transition from WeekTwo image only, I believe"
	clippingCanvas _ aCanvas copyClipRect: bounds.
	self drawOn: clippingCanvas.
	submorphs isEmpty ifFalse:
		[submorphs reverseDo: [:m | m fullDrawOn: clippingCanvas]].  "draw back-to-front"
