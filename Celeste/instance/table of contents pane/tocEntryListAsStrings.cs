tocEntryListAsStrings
	"return a list of one-line strings, one line for each currently-selected message"

	mailDB ifNil: [ ^#() ].

	^currentMessages collectWithIndex: [ :msgID :index |
		index printString, ' ', (mailDB getTOCentry: msgID) computeTOCString ].

