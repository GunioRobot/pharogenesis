reset
	"Reset this Wonderland"

	| ground |

	"Reset the scheduler"
	myScheduler reset.

	"Reset the shared mesh and texture directories"
	sharedMeshDict _ Dictionary new.
	sharedTextureDict _ Dictionary new.

	"Reset the list of actor uniclasses"
	actorClassList do: [:aClass | aClass removeFromSystem ].
	actorClassList _ OrderedCollection new.

	"Initialize this Wonderland's shared namespace"
	myNamespace _ WonderlandConstants copy.

	"Rebuild the namespace"
	myNamespace at: 'scheduler' put: myScheduler.
	myNamespace at: 'w' put: self.

	"Create a new scene"
	sceneObject _ WonderlandScene newFor: self.
	myNamespace at: 'scene' put: sceneObject.

	"Recreate the default objects"
	ground _ self makeActor.
	ground setMesh: (WonderlandConstants at: 'groundMesh').
	ground setTexturePointer: (WonderlandConstants at: 'groundTexture').
	ground becomePart.
	ground setName: 'ground'.
	ground setColor: {0.2902. 0.8000. 0.0000} duration: rightNow.
	myNamespace at: 'ground' put: ground.

	"Re-initialize the light list and create a default light"
	lightList _ OrderedCollection new.
	self makeLight.
	lightList last moveTo: {0. 2. 0} duration: rightNow.

	"Wipe out the existing cameras"
	cameraList do: [:camera | camera release].
	
	"Recreate the default camera"
	cameraList _ OrderedCollection new.
	defaultCamera _ self makeCamera.

	"Reset the script editor's namespace"
	scriptEditor resetNamespace.

	"Update the actor browser"
	scriptEditor updateActorBrowser.

	"Reset the undo stack"
	myUndoStack reset.


