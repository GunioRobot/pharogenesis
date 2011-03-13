model: aModel
	model ifNotNil: [model removeDependent: self].
	model _ aModel.
	model addDependent: self.