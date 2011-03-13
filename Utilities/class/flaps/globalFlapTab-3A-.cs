globalFlapTab: aName
	| nn |
	"Find a global flap tab by name.  May be either 'flap: Tools' or 'Tools'. "

	nn _ (aName beginsWith: 'flap: ') ifTrue: [aName] ifFalse: ['flap: ', aName].
	^ self globalFlapTabsIfAny detect: [:ft | ft flapMenuTitle = nn] ifNone: [nil]