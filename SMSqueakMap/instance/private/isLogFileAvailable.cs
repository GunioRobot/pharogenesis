isLogFileAvailable
	"Check that there is an 'sm' directory
	and that it contains at least one logfile."

	[self logFileName] on: Error do: [:ex | ^false].
	^true