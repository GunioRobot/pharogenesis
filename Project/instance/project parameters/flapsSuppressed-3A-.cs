flapsSuppressed: aBoolean
	self projectParameters at: #globalFlapsEnabledInProject put: aBoolean not.
	aBoolean
		ifTrue:		
			[Utilities globalFlapTabsIfAny do:
				[:aFlapTab | Utilities removeFlapTab: aFlapTab keepInList: true]]

		ifFalse:
			[Smalltalk isMorphic  ifTrue:
				[self currentWorld addGlobalFlaps]]