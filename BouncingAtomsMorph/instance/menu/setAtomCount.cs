setAtomCount

	| countString count |
	countString _ FillInTheBlank
		request: 'Number of atoms?'
		initialAnswer: self submorphCount printString.
	countString isEmpty ifTrue: [^ self].
	count _ Integer readFrom: (ReadStream on: countString).
	self removeAllMorphs.
	self addAtoms: count.
