acceptDroppingMorph: aMorph event: evt

	| editor wasPossessive |
	wasPossessive _ submorphs size > 0 and: [submorphs first isPossessive].
	self prepareToUndoDropOf: aMorph.
	self removeAllMorphs.
	aMorph position: self position.
	self addMorph: aMorph.
	wasPossessive ifTrue: [aMorph bePossessive].
	(editor _ self topEditor) ifNotNil: [editor install]
