initialize
	super initialize.
	modelMatrix _ B3DMatrix4x4 identity.
	viewMatrix _ B3DMatrix4x4 identity.
	textureMatrix _ B3DMatrix4x4 identity.
	currentMatrix _ modelMatrix.
	matrixStack _ OrderedCollection new: 30.
	matrixStack resetTo: 1.
	needsUpdate _ false.