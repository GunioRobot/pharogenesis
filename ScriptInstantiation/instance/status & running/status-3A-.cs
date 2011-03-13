status: newStatus
	| stati actualMorph |
	actualMorph _ player costume renderedMorph.
	((stati _ ScriptingSystem standardEventStati) includes: status)
		ifTrue:
			[actualMorph on: status send: nil to: nil].  			"remove old link in event handler"
	(stati includes: newStatus)
		ifTrue:
			[actualMorph on: newStatus send: selector to: player].  "establish new link in evt handler"

	status _ newStatus