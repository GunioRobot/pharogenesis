typedCommandsForBank: aBank
	"Return a list of typed-command arrays of the form:
		<result type> <command> <argType>"

	^ (self standardCommandsForBank: aBank), (self tileScriptCommandsForBank: aBank)