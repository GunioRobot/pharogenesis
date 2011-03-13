maybeLogMessage
	"Return a string for logging this message, if there is one"
	^'RemovePackage ', username, ' ', packageName, '/', packageVersion printString