removeFlapTab: aFlapTab keepInList: aBoolean
	(FlapTabs ~~ nil and: [FlapTabs includes: aFlapTab])
		ifTrue:
			[aBoolean ifFalse: [FlapTabs remove: aFlapTab].
			aFlapTab referent delete.
			aFlapTab delete]