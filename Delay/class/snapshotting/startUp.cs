startUp
	"Restart active delay, if any, when resuming a snapshot."

	ActiveDelay == nil ifFalse: [ ActiveDelay continueAfterSnapshot ].
	AccessProtect signal.
