initializeFor: aWonderland
	"Initialize the instance variables for the WonderlandActor"

	super initialize.

	myName _ 'Unnamed'.
	myWonderland _ aWonderland.
	myParent _ aWonderland getScene.
	myParent addChild: self.

	"Initialize our material"
	myMaterial _ B3DMaterial new.
	myMaterial ambientPart: Color white.
	myMaterial diffusePart: Color white.
	myMaterial specularPart: Color white.

	"Set up our default properties"
	myColor _ B3DColor4 r: 1.0 g: 1.0 b: 1.0 a: 1.0.
	composite _ B3DMatrix4x4 identity.
	scaleMatrix _ B3DMatrix4x4 identity.

	"Setup the default reactions"
	self initializeDefaultReactions.

	hidden _ false.
	firstClass _ true.
