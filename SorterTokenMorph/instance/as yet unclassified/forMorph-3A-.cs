forMorph: aMorph
	| it |
	morphRepresented _ aMorph.
	aMorph submorphs size > 0 ifTrue:
		[self addMorphBack: (it _ aMorph submorphs first fullCopy).
		it position: self position + (1@1).
		it lock].
	self fitContents