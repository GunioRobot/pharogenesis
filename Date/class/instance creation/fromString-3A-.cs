fromString: aString
	"Answer an instance of created from a string with format DD.MM.YYYY."

	| fields |
	fields := aString findTokens: './'.
	^self newDay: (fields at: 1) asNumber month: (fields at: 2) asNumber year: (fields at: 3) asNumber