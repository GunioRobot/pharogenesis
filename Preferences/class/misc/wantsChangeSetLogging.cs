wantsChangeSetLogging
	"Answer whether method changes in the receiver should be logged to current change set.  This circumlocution avoids such logging for programmatically-compiled methods in Preferences, removing an annoyance"

	^ Author fullNamePerSe  ~= 'programmatic'