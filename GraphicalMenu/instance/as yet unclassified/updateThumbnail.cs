updateThumbnail
	| f scaleY scaleX maxWidth stdHeight |
	maxWidth _ 100.
	stdHeight _ 80.
	f _ formChoices at: currentIndex.
	scaleY _ stdHeight / f height.  "keep height invariant"
	scaleY _ scaleY min: 1.
	scaleX _ ((f width * scaleY) <= maxWidth)
		ifTrue:
			[scaleY]
		ifFalse:
			[maxWidth / f width].
	formDisplayMorph image: (f magnify: f boundingBox by: (scaleX @ scaleY) smoothing: 2).
	formDisplayMorph layoutChanged