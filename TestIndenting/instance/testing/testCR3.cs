testCR3
	"Checks whether the beginning of a new line starts at the indented position"
	| cb |
	para replaceFrom: 11 to: 11 with: (Text string: (String with: Character cr) attribute: (TextIndent tabs: 1)) displaying: false.
	para clippingRectangle: (0@0 extent: 200@200).
	cb := para characterBlockForIndex: 12.
	self assert: cb top > 0.
	self assert: cb left = 24