initialize
	"This method initializes the Wonderland."

	| ground |

	"Initialize the list of actor UniClasses"
	actorClassList _ OrderedCollection new.

	"Initialize the shared mesh and texture directories"
	sharedMeshDict _ Dictionary new.
	sharedTextureDict _ Dictionary new.

	"Initialize this Wonderland's shared namespace"
	myNamespace _ WonderlandConstants copy.

	"Create the Wonderland's scheduler"
	myScheduler _ Scheduler new.
	myNamespace at: 'scheduler' put: myScheduler.

	"Create the undo stack for this Wonderland."
	myUndoStack _ WonderlandUndoStack new.

	"The scene object is the root of the object tree - all objects in the Wonderland are children (directly or indirectly) of the scene. "
	sceneObject _ WonderlandScene newFor: self.
	myNamespace at: 'scene' put: sceneObject.

	"Create a script editor for this Wonderland"
	self makeScriptEditor.

	"Create some default objects"
	ground _ self makeActor.
	ground setMesh: (WonderlandConstants at: 'groundMesh').
	ground setTexturePointer: (WonderlandConstants at: 'groundTexture').
	ground becomePart.
	ground setColor: {0.2902. 0.8000. 0.0000} duration: rightNow.
	ground setName: 'ground'.
	myNamespace at: 'ground' put: ground.

	"Initialize the light list and create a default light"
	lightList _ OrderedCollection new.
	self makeLight.
	lightList last moveTo: {0. 2. 0} duration: rightNow.
	
	"Create the default camera"
	cameraList _ OrderedCollection new.
	defaultCamera _ self makeCamera.

	"Clean out the Undo stack - we don't want people undoing the init stuff"
	myUndoStack reset.

	"Throw this Wonderland into the shared namespace"
	myNamespace at: 'w' put: self.

