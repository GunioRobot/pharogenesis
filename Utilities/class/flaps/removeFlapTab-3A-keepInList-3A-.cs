removeFlapTab: aFlapTab keepInList: aBoolean
	"Remove the given flap tab from the screen, and, if aBoolean is true, also from the global list"

	(FlapTabs ~~ nil and: [FlapTabs includes: aFlapTab])
		ifTrue:
			[aBoolean ifFalse: [self removeFromGlobalFlapTabList: aFlapTab].
			aFlapTab referent delete.
			aFlapTab delete]