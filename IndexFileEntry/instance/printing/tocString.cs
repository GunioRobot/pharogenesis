tocString
	"Answer a string for the table of contents."

	(tocLineCache isNil) ifTrue:
		[tocLineCache _ self computeTOCString].
	^tocLineCache