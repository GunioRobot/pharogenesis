field: field has: stringOrList
	"Return true if either the given field contains the argument string or, if the argument is a collection, return true if the given field contains any of the strings in that collection."

	| s |
	(stringOrList isKindOf: String) ifTrue: [
		^ field includesSubstring: stringOrList caseSensitive: false
	] ifFalse: [
		1 to: stringOrList size do: [ :i |
			s _ stringOrList at: i.
			s isNumber ifTrue: [s _ s printString].
			(field includesSubstring: s caseSensitive: false) ifTrue: [^ true].
		].
		^ false
	].