matrixMode: aSymbol
	aSymbol == #modelView ifTrue:[currentMatrix := modelMatrix. ^self].
	aSymbol == #projection ifTrue:[currentMatrix := viewMatrix. ^self].
	aSymbol == #texture ifTrue:[currentMatrix := textureMatrix. ^self].
	self error:'Bad matrix mode'.