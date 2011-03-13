providePossibleRestrictedView: anInteger

	| who |
	restrictedIndex _ anInteger.
	who _ scriptedPlayer whoAt: anInteger.
	restrictedWho = who ifTrue: [^ self].
	restrictedWho _ who.
	stub who: who.
	who = 0 ifTrue: [self replaceTargetsWithExampler] ifFalse: [self replaceTargetsWithStub].
	self searchingViewerMorphs do: [:v | v updateWhoString].
