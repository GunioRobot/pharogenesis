makeActorFromVRML: filename named: actorName
	"Creates a new actor using the specification from the given file"
	| baseActor parserClass builderClass scene |

	parserClass _ Smalltalk at: #VRMLNodeParser ifAbsent:[
		self reportErrorToUser:'No VRML parser found'.
		^self].
	builderClass _ Smalltalk at: #VRMLWonderlandBuilder ifAbsent:[
		self reportErrorToUser:'No VRML to Alice converter found'.
		^self].
	myUndoStack closeStack.
	baseActor _ self makeBaseActorFrom: filename.
	baseActor setName: (self uniqueNameFrom: actorName).
	parserClass == nil
		ifFalse:[scene _ parserClass parseFileNamed: filename].
	(builderClass == nil or:[scene == nil])
		ifFalse:[(builderClass on: scene) 
					baseActor: baseActor;
					buildActorsFor: self].
	myUndoStack openStack.

	"Ensure that the new actor's name is unique"
	myNamespace at: baseActor getName put: baseActor.
	scriptEditor updateActorBrowser.

	"Add an undo item to undo the creation of this object"
	myUndoStack push: (UndoAction new: [ baseActor removeFromScene.
											myNamespace removeKey: baseActor getName ifAbsent: [].
											scriptEditor updateActorBrowser.  ] ).

	^ baseActor.
