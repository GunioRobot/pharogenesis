makeCameraNamed: aString
	"Add a new camera to the Wonderland"
	| newClass newCamera name windowName |
	newClass _ WonderlandCamera newUniqueClassInstVars: '' classInstVars: ''.
	newCamera _ newClass createFor: self.
	newCamera getMorph openInWorld.
	actorClassList addLast: newClass.

	name _ self uniqueNameFrom: aString.
	newCamera setName: name.
	myNamespace at: name put: newCamera.

	windowName _ self uniqueNameFrom: aString,'Window'.
	myNamespace at: windowName put: (newCamera getMorph).

	cameraList addLast: newCamera.
	scriptEditor updateActorBrowser.

	"Add an undo action to remove this camera"
	myUndoStack push: (UndoAction new: [  cameraList remove: newCamera.
											newCamera removeFromScene.
											myNamespace removeKey: name ifAbsent: [].
											myNamespace removeKey: windowName.
											newCamera release.
											scriptEditor updateActorBrowser ]).

	^ newCamera.
