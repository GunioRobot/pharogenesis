lines
	"Other than my member paragraph i compute lines based on logical
	line breaks, not optical (which may change due to line wrapping of the editor)"
	| lines string index lineIndex stringSize |
	string _ paragraph text string.
	"Empty strings have no lines at all. Think of something."
	string isEmpty ifTrue:[^{#(1 0 0)}].
	stringSize _ string size.
	lines _ OrderedCollection new: (string size // 15).
	index _ 0.
	lineIndex _ 0.
	string linesDo:[:line |
		lines addLast: (Array
			with: (index _ index + 1)
			with: (lineIndex _ lineIndex + 1)
			with: (index _ index + line size min: stringSize))].
	"Special workaround for last line empty."
	string last == Character cr
	"lines last last < stringSize" ifTrue:[lines addLast:{stringSize +1. lineIndex+1. stringSize}].
	^lines