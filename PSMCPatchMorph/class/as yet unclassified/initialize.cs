initialize
	"Set up extra diff preferences here."

	Preferences
		addPreference: #useNewDiffToolsForMC
		categories: #(browsing)
		default: true
		balloonHelp: 'When enabled the Polymorph diff tools will be used with Monticello. When diabled, the original tools are used.' translated