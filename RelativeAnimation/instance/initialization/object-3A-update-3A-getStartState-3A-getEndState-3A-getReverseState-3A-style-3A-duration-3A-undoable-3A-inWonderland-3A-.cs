object: anObject update: func getStartState: startFunc getEndState: endFunc getReverseState: reverseFunc style: styleFunc duration: time undoable: canUndo inWonderland: aWonderland
	"This method initializes the Animation with all the information that it needs to run."

	getReverseStateFunction _ reverseFunc.

	super object: anObject update: func getStartState: startFunc getEndState: endFunc style: styleFunc duration: time undoable: canUndo inWonderland: aWonderland.
