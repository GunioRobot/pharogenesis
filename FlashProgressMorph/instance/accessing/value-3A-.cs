value: aModel
	value ifNotNil: [value removeDependent: self].
	value _ aModel.
	value ifNotNil: [value addDependent: self]