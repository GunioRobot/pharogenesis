mouseDown: evt
	"Handle a mouse down event."

	myUndoStack push: (UndoPOVChange for: myCamera from: (myCamera getPointOfView)).

	moveAction _ myCamera doEachFrame: [self moveCamera: World primaryHand lastEvent].
