layoutPolicy
	"Layout specific. Return the layout policy describing how children 
	of the receiver should appear."
	^ self hasExtension
		ifTrue: [ self extension layoutPolicy]