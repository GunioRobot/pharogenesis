initialize
	"Initialize the Alice world"

	| defaultCamera |

	"Initialize this Wonderland's shared namespace"
	myNamespace _ AliceNamespace new.
	myNamespace at: 'world' put: self.

	"Create the Wonderland's scheduler"
	myScheduler _ AliceScheduler new.
	myNamespace at: 'scheduler' put: myScheduler.

	"Initialize the list of actor UniClasses"
	actorClassList _ OrderedCollection new.

	"Initialize the shared mesh and texture directories"
	sharedMeshDict _ Dictionary new.
	sharedTextureDict _ Dictionary new.

	"Create an output window for us to dump text to"
	myTextOutputWindow _ AliceTextOutputWindow new.
	myTextOutputWindow setText: 'Squeak Alice v2.0.'.

	cameraList _ OrderedCollection new.
	lightList _ OrderedCollection new.

	"-------------------------------"

	"Create the undo stack for this Wonderland."
	myUndoStack _ WonderlandUndoStack new.

	"The scene object is the root of the object tree - all objects in the Wonderland are children (directly or indirectly) of the scene. "
	myScene _ WonderlandScene newFor: self.
	myNamespace at: 'scene' put: myScene.

	"Create the default camera"
	defaultCamera _ WonderlandCamera createFor: self.
	cameraList addLast: defaultCamera.
	myNamespace at: 'camera' put: defaultCamera.
	myNamespace at: 'cameraWindow' put: (defaultCamera getMorph).
	defaultCamera setName: 'camera'.

	myUndoStack reset.
