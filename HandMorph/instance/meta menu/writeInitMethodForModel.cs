writeInitMethodForModel

	| model |
	model _ self world model.
	model class chooseNewName.
	model fullCopy compileInitMethods.
