testCR
	"Checks whether the beginning of a new line starts at the indented position"
	| cb |
	para replaceFrom: 7 to: 7 with: (String with: Character cr) displaying: false.
	para clippingRectangle: (0@0 extent: 200@200).
	cb := para characterBlockForIndex: 8.
	self assert: cb top > 0.
	self assert: cb left = 24