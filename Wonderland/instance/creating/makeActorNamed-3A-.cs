makeActorNamed: aString
	"Creates a new actor without any geometry"

	| newClass newActor name |

	newClass _ WonderlandActor newUniqueClassInstVars: '' classInstVars: ''.
	newActor _ (newClass createFor: self).
	actorClassList addLast: newClass.

	scriptEditor ifNotNil: [ 
				name _ self uniqueNameFrom: aString.
				newActor setName: name.
				myNamespace at: name put: newActor.
				scriptEditor updateActorBrowser.
						].

	"Add an undo item to undo the creation of this object"
	myUndoStack push: (UndoAction new: [ newActor removeFromScene.
											myNamespace removeKey: name ifAbsent: [].
						 					scriptEditor updateActorBrowser. ]).

	^ newActor.
