addChild: aChild
	"Add an object to this instance's list of children"

	((myChildren identityIndexOf: aChild) = 0) ifTrue: [ myChildren addLast: aChild ].
