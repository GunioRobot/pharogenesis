packageWithId: anIdString
	"Return the correct package or nil."

	| uuid |
	uuid _ UUID fromString: anIdString.
	^self packages detect: [:p | p id = uuid ] ifNone: [nil]