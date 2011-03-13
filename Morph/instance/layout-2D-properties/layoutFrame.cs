layoutFrame
	"Layout specific. Return the layout frame describing where the receiver should appear in a proportional layout"
	extension == nil ifTrue:[^nil].
	^extension layoutFrame