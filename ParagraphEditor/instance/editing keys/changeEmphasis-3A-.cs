changeEmphasis: characterStream
	"Change the emphasis of the current selection or prepare to accept 
	characters with the change in emphasis. Emphasis change amounts to a 
	font change.  Keeps typeahead."

	| newCode |
	newCode _ (sensor keyboard asciiValue - $0 asciiValue) + 1.
	beginTypeInBlock ~~ nil
		ifTrue:  "only change emphasisHere while typing"
			[self insertTypeAhead: characterStream.
			emphasisHere _ newCode.
			^true].
	self replaceSelectionWith:
		(Text string: self selection asString emphasis: (newCode max: 1)).
	^true