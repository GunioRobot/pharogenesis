unhighlightOwner
	"Unhighlight my owner"

	(owner ~~ nil and: [owner isSyntaxMorph])
		ifTrue: [owner unhighlight]