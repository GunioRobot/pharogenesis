registerPreferences
	"Registers a preference to run abstract test classes"

	Preferences
		addPreference: #testRunnerShowAbstractClasses
		categories: #(#sunit )
		default: false
		balloonHelp: 'If true, the test testrunner shows abstract classes'
