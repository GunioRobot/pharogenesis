layoutFrame
	"Layout specific. Return the layout frame describing where the  
	receiver should appear in a proportional layout"
	^ self hasExtension
		ifTrue: [ self extension layoutFrame]