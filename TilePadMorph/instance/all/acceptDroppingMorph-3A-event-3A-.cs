acceptDroppingMorph: aMorph event: evt

	| editor |
	self prepareToUndoDropOf: aMorph.
	self removeAllMorphs.
	aMorph position: self position.
	self addMorph: aMorph.
	(editor _ self topEditor) ifNotNil: [editor install].  "accept the change now"
