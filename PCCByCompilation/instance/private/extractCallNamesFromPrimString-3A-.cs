extractCallNamesFromPrimString: aString
	"method works for both enabled and disabled prim strings"
	"<primitive: 'doSomething' module:'ModuleFoo'"
	| tokens |
	tokens := aString findTokens: ''''.
	^ (tokens at: 2) -> (tokens at: 4 ifAbsent: [nil])