defaultWindow
	"Return a rectangle large enough to contain this button's label. If this button is label-less, just return the standard View default window."

	label == nil
		ifTrue: [^ super defaultWindow]
		ifFalse: [^ label boundingBox expandBy: 6].
