prepareToUndoDropOf: aMorph

	| m |
	self mouseLeave: MouseMoveEvent new.
	m _ self owner.
	[m == nil] whileFalse: [
		(m isKindOf: ScriptEditorMorph) ifTrue: [^ m prepareToUndoDropOf: aMorph].
		m _ m owner].
