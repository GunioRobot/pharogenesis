toggleProjectLocalness
	"Toggle whether the preference should be held project-by-project or globally"

	localToProject _ localToProject not.
	PreferencesPanel allInstancesDo:
		[:aPanel | aPanel adjustProjectLocalEmphasisFor: name].
