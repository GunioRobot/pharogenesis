notePriorDefinition: oldClass

	oldClass ifNil: [^ self].
	priorDefinition ifNil: [priorDefinition _ oldClass definition]