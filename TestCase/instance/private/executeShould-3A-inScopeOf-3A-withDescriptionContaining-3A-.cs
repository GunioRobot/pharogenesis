executeShould: aBlock inScopeOf: anExceptionalEvent withDescriptionContaining: aString
	^[aBlock value.
 	false] sunitOn: anExceptionalEvent
		do: [:ex | ex sunitExitWith: (ex description includesSubString: aString) ]
			