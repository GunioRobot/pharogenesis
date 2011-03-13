layoutPolicy
	"Layout specific. Return the layout policy describing how children of the receiver should appear."
	extension == nil ifTrue:[^nil]. "shortcut for speed"
	^extension layoutPolicy