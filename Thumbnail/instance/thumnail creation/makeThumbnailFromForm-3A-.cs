makeThumbnailFromForm: aForm
	"Make a thumbnail from the form provided, obeying my min and max width and height preferences"

	|  scaleX scaleY margin opaque |
	scaleY _ minimumHeight / aForm height.  "keep height invariant"
	scaleX _ ((aForm width * scaleY) <= maximumWidth)
		ifTrue: [scaleY]  "the usual case; same scale factor, to preserve aspect ratio"
		ifFalse: [scaleY _ maximumWidth / aForm width].

	"self form: (aForm magnify: aForm boundingBox by: (scaleX @ scaleY) smoothing: 2)."
	"Note: A problem with magnify:by: fails to reproduce borders properly.
		The following code does a better job..."
	margin _ 1.0 / (scaleX@scaleY) // 2 max: 0@0.  "Extra margin around border"
	opaque _ (Form extent: aForm extent + margin depth: 32) "fillWhite".
	aForm fixAlpha displayOn: opaque at: aForm offset negated rule: Form blendAlpha.  "Opaque form shrinks better"
	opaque fixAlpha.
	self form: (opaque magnify: opaque boundingBox by: (scaleX @ scaleY) smoothing: 2).

	self extent: originalForm extent