executeShould: aBlock inScopeOf: anExceptionalEvent withDescriptionNotContaining: aString
	^[aBlock value.
 	false] sunitOn: anExceptionalEvent
		do: [:ex | ex sunitExitWith: (ex description includesSubString: aString) not ]
			