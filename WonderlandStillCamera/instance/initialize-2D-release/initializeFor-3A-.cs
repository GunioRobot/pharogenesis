initializeFor: aWonderland
	"Initializes the camera."

	super initializeFor: aWonderland.

	"Set the camera's mesh and geometry"
	self setMesh: nil.
	self setTexturePointer: nil.

	"Delete the WonderlandCameraMorph our superclass created"
	myMorph delete.	

	"Create a WonderlandStillCameraMorph for the camera to render into"
	myMorph _ WonderlandStillCameraMorph new.
	myMorph initializeWithCamera: self.
	myMorph openInWorld.

	"Initially we aren't focusing on any particular object"
	focusObject _ nil.

	"Initially draw the scene background"
	drawSceneBackground _ true.
