reset
	super reset.
	modelMatrix := B3DMatrix4x4 identity.
	viewMatrix := B3DMatrix4x4 identity.
	textureMatrix := B3DMatrix4x4 identity.
	currentMatrix := modelMatrix.
	matrixStack := OrderedCollection new: 30.
	matrixStack resetTo: 1.
	needsUpdate := false.