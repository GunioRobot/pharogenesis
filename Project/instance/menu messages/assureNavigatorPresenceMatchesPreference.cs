assureNavigatorPresenceMatchesPreference
	"Make sure that the current project conforms to the presence/absence of the navigator"

	| navigator navType wantIt |
	Smalltalk isMorphic ifFalse: [^ self].
	wantIt _  Preferences classicNavigatorEnabled and: [Preferences showProjectNavigator].
	navType _ ProjectNavigationMorph preferredNavigator.
	navigator _ world findA: navType.
	wantIt
		ifFalse:
			[navigator ifNotNil: [navigator delete]]
		ifTrue:
			[navigator isNil ifTrue: 
				[(navigator _ navType new)
					bottomLeft: world bottomLeft;
					openInWorld: world]]