initializeFor: anAliceWorld
	"Initialize the instance variables for the AliceActor"

	super initialize.

	myName _ 'Unnamed'.
	myWorld _ myWorld.
	myParent _ myWorld getScene.
	myParent addChild: self.

	"Initialize our material"
	myMaterial _ B3DMaterial new.
	myMaterial ambientPart: Color white.
	myMaterial diffusePart: Color white.
	myMaterial specularPart: Color white.

	"Set up our default properties"
	myColor _ B3DColor4 r: 1.0 g: 1.0 b: 1.0 a: 1.0.
	compositeMatrix _ B3DMatrix4x4 identity.
	scaleMatrix _ B3DMatrix4x4 identity.

	isHidden _ false.
	isFirstClass _ true.
