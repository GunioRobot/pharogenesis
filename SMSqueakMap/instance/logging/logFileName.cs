logFileName
	"Pick the newest logfile available."

	^self directory lastNameFor: 'squeakmap' extension: 'log'