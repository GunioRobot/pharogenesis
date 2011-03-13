selectLastPrefix: aString
	"Answer the last subitem that has text that matches the given prefix.
	Answer nil if none.
	Disable non-matching items and enable matching items."

	|firstMatch match|
	self items reverseDo: [:item |
		match := aString isEmpty or: [item contents asString asLowercase beginsWith: aString].
		item isEnabled: match.
		(match and: [firstMatch isNil]) ifTrue: [firstMatch := item]].
	^firstMatch