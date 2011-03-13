noteDeletionOf: aMorph fromWorld: aWorld
	"aMorph, while pointing to me as its costumee, has been deleted"
	"This may be too aggressive because deletion of a morph may not really mean deletion of its associated player -- in light of hoped-for multiple viewing"

	| viewers scriptors |
	viewers _ OrderedCollection new.
	scriptors _ OrderedCollection new.
	aWorld allMorphs do:
		[:m | (m isKindOf: PartsViewer) ifTrue: [viewers add: m].
			((m isKindOf: ScriptEditorMorph) and: [m myMorph == aMorph])
				ifTrue: [scriptors add: m]].

	viewers do: [:v |  v noteDeletionOf: aMorph].
	scriptors do: [:s | s privateDelete] 