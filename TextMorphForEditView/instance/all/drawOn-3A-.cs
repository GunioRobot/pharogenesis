drawOn: aCanvas
	self setDefaultContentsIfNil.
	"self startingIndex > text size" false "try out" ifFalse:
		[aCanvas newParagraph: self paragraph bounds: bounds color: color].