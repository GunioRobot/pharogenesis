fullDrawOn: aCanvas
	"Overridden to clip submorph drawing to my bounds if clipping is true."

	| clippingCanvas |
	clipping ifFalse: [^ super fullDrawOn: aCanvas].
	(aCanvas isVisible: self bounds) ifFalse: [^ self].
	self drawOn: aCanvas.
	clippingCanvas _ aCanvas copyClipRect: bounds.
	submorphs isEmpty ifFalse: [
		submorphs reverseDo: [:m | m fullDrawOn: clippingCanvas]].  "draw back-to-front"
