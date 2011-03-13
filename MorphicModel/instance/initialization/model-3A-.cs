model: aModel
	model _ aModel.
	aModel ifNotNil: [aModel addDependent: self]