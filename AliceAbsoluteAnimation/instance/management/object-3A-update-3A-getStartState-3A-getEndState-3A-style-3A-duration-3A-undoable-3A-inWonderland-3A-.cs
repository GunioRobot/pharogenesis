object: anObject update: func getStartState: startFunc getEndState: endFunc style: styleFunc duration: time undoable: canUndo inWonderland: aWonderland
	"This method initializes the animation with all the information that it needs to run."

	lastStartState _ startFunc value.

	super object: anObject update: func getStartState: startFunc getEndState: endFunc style: styleFunc duration: time undoable: canUndo inWonderland: aWonderland.
