localFlapTabs
	| globalList aList aFlapTab |
	globalList _ Utilities globalFlapTabsIfAny.
	aList _ OrderedCollection new.
	submorphs do:
		[:m | ((m isKindOf: FlapTab) and: [(globalList includes: m) not])
			ifTrue:
				[aList add: m]
			ifFalse:
				[((m hasProperty: #flap) and:
					[(aFlapTab _ m submorphs detect: [:n | n isKindOf: FlapTab] ifNone: [nil]) notNil])
						ifTrue:
							[aList add: aFlapTab]]].
	^ aList