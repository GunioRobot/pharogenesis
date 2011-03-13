step

	owner == self world ifFalse: [^ self].
	owner addMorphInLayer: self.
