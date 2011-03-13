enclosingEditor
	"Return the next scriptor outward in the containment hierarchy"
	^ self firstOwnerSuchThat:
		[:m | (m isKindOf: ScriptEditorMorph) or: [m isKindOf: CompoundTileMorph]]