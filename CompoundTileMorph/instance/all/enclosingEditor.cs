enclosingEditor
	"Return the next scriptor outward in the containment hierarchy"
	| current |
	current _ owner.
	[current == nil] whileFalse:
		[((current isKindOf: ScriptEditorMorph)
				or: [current isKindOf: CompoundTileMorph])
			ifTrue: [^ current].
		current _ current owner].
	^ nil