initializeFor: aWonderland
	"Initializes the camera."

	super initializeFor: aWonderland.

	"Set the camera's mesh and geometry"
	self setMesh: (WonderlandConstants at: 'cameraMesh').
	self setTexturePointer: (WonderlandConstants at: 'cameraTexture').
	
	"Set the camera initial position"
	composite translation: (B3DVector3 x: -1.5 y: 0.5 z: 2.6).
	self turnTo: #(180 -30 180) duration: #rightNow.

	"Initialize the camera viewing parameters"
	perspective _ B3DCameraPerspective new.
	self setFieldOfView: 40.0.
	self setAspectRatio: 1.0.
	self setNearClippingPlane: 0.1.
	self setFarClippingPlane: 10000.0.

	viewMatrix _ B3DMatrix4x4 new.

	"Create a WonderlandCameraMorph for the camera to render into"
	myMorph _ WonderlandCameraMorph new.
	myMorph initializeWithCamera: self.
	myMorph openInWorld.

	"Initially draw the scene background"
	drawSceneBackground _ true.
