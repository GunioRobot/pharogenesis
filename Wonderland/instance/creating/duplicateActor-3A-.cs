duplicateActor: anActor
	"Creates a new actor without any geometry"
	| newActor |
	newActor _ anActor clone postCopy.
	anActor getParent == nil ifTrue:[
		newActor setName: (self uniqueNameFrom: newActor getName).
		myNamespace at: newActor getName put: newActor.
	] ifFalse:[
		newActor setName: (anActor getParent uniqueNameFrom: newActor getName).
		anActor getParent addChild: newActor.
		newActor setParent: anActor getParent.
	].

	scriptEditor updateActorBrowser.

	"Add an undo item to undo the creation of this object"
	myUndoStack push: (UndoAction new: [ newActor removeFromScene.
						 					scriptEditor updateActorBrowser. ]).

	^ newActor.
