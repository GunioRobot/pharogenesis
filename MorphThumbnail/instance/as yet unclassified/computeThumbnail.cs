computeThumbnail
	"Assumption on entry:
       The receiver's width represents the maximum width allowable.
       The receiver's height represents the exact height desired."

	| f scaleX scaleY |
	f _ morphRepresented imageForm.
	morphRepresented fullReleaseCachedState.
	scaleY _ self height / f height.  "keep height invariant"
	scaleX _ ((morphRepresented width * scaleY) <= self width)
		ifTrue:
			[scaleY]  "the usual case; same scale factor, to preserve aspect ratio"
		ifFalse:
			[self width / f width].
	self form: (f magnify: f boundingBox by: (scaleX @ scaleY) smoothing: 2).
	self extent: originalForm extent