duplicateActor: anActor
	"Creates a new actor without any geometry"
	| newActor |
	newActor _ anActor clone postCopy.
	anActor getParent == nil ifFalse:[
		anActor getParent addChild: newActor.
		newActor setParent: anActor getParent].
	newActor setName: anActor getName,'2'.
	scriptEditor updateActorBrowser.

	"Add an undo item to undo the creation of this object"
	myUndoStack push: (UndoAction new: [ newActor removeFromScene.
						 					scriptEditor updateActorBrowser. ]).

	^ newActor.
