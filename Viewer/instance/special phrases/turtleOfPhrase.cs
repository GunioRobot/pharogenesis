turtleOfPhrase

	| outerPhrase getTile |
	outerPhrase := PhraseTileMorph new 
				setOperator: #+
				type: #Player
				rcvrType: #Player
				argType: #Color.	"temp dummy"
	(outerPhrase submorphs second) delete.	"operator"
	(outerPhrase submorphs second) delete.	"color"
	getTile _ KedamaTurtleOfTile new.
	outerPhrase addMorphBack: getTile.
	^outerPhrase