checkDoneAfter: move

	| team locsAfterMove |
	(team := self at: move first) = 0 ifTrue: [^ false].
	(locsAfterMove _ (teams at: team) copy) replaceAll: move first with: move last.
	^ self testDone: locsAfterMove for: team