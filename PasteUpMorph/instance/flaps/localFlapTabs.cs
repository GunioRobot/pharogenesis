localFlapTabs
	"Answer a list of local flap tabs in the current project"

	| globalList aList aFlapTab |
	globalList _ Flaps globalFlapTabsIfAny.
	aList _ OrderedCollection new.
	submorphs do:
		[:m | ((m isFlapTab) and: [(globalList includes: m) not])
			ifTrue:
				[aList add: m]
			ifFalse:
				[((m isFlap) and:
					[(aFlapTab _ m submorphs detect: [:n | n isFlapTab] ifNone: [nil]) notNil])
						ifTrue:
							[aList add: aFlapTab]]].
	^ aList