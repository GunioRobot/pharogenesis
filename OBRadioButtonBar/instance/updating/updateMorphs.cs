updateMorphs
	self removeAllMorphs.
	buttons do: [:button | self addMorphBack: button morph].
	self bounds: (self bounds withHeight: submorphs first height)