abandonOldReferenceScheme
	"Perform a one-time changeover"
	"ActiveWorld abandonOldReferenceScheme"

	Preferences setPreference: #capitalizedReferences toValue: true.
	(self presenter allExtantPlayers collect: [:aPlayer | aPlayer class]) asSet do:
			[:aPlayerClass |
				aPlayerClass isUniClass ifTrue:
					[aPlayerClass abandonOldReferenceScheme]]