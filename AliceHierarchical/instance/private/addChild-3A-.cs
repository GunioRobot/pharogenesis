addChild: aChild
	"Add an object to this instance's list of children. Checks to make sure that aChild is not already a child of this object"

	((myChildren identityIndexOf: aChild) = 0) ifTrue: [ myChildren addLast: aChild ].
