makeAllScriptEditorsReferToMasters
	"Ensure that all script editors refer to the first (by alphabetical externalName) Player among the list of siblings"

	(self presenter allExtantPlayers groupBy: [ :p | p class ] having: [ :p | true ])
		do: [ :group | group first allScriptEditors ]