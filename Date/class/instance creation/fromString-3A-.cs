fromString: aString
	"Answer an instance of created from a string with format DD.MM.YYYY."

	^self readFrom: (ReadStream on: aString).
