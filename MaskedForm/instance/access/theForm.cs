theForm
	"Return the original Form.  Restore it's transparent color if it was zeroed to make the area truly transparent.  6/22/96 tk"

	| copy |
	transparentPixelValue == nil ifTrue: [^ theForm].
	copy _ self deepCopy.	"Use one in Object"
	copy restoreOverlap.
	^ copy theForm		"won't recurse because transparentPixelValue is now nil"