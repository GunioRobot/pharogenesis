matrixMode
	currentMatrix == modelMatrix ifTrue:[^#modelView].
	currentMatrix == viewMatrix ifTrue:[^#projection].
	currentMatrix == textureMatrix ifTrue:[^#texture].
	self error:'Bad matrix state'.