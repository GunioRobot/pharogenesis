fullDrawOn: aCanvas
	"Overridden to clip submorph drawing to my bounds."

	| clippingCanvas |
	(aCanvas isVisible: self bounds) ifFalse: [^ self].
	self drawOn: aCanvas.
	clippingCanvas _ aCanvas copyClipRect: bounds.
	submorphs isEmpty ifFalse: [
		submorphs reverseDo: [:m | m fullDrawOn: clippingCanvas]].  "draw back-to-front"
