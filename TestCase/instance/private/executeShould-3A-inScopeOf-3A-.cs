executeShould: aBlock inScopeOf: anExceptionalEvent 
	^[aBlock value.
 	false] sunitOn: anExceptionalEvent
		do: [:ex | ex sunitExitWith: true]
			