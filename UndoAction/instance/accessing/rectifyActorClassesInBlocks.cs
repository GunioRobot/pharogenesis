rectifyActorClassesInBlocks  "UndoAction allInstancesDo: [:ua | ua rectifyActorClassesInBlocks]"
	"Rectify obsolete class refs held onto by UndoActions"

	| ctxt obs |
	ctxt _ wrappedAction home.
	1 to: ctxt size do:
		[:i | obs _ ctxt at: i.
		((obs isKindOf: Behavior) and: [obs isObsolete])
			ifTrue: [ctxt at: i put: obs nonObsoleteClass]]