adjustHelpMessage
	"Adjust the help message to reflect the new literal"

	(ScriptingSystem helpStringOrNilForOperator: literal) ifNotNilDo:
		[:aString |
			self labelMorph setBalloonText: aString]