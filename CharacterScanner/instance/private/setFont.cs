setFont 
	"Set the font and the stop conditions for the font."
	| newFont |
	newFont _ textStyle fontAt: (text emphasisAt: lastIndex).
	font == newFont ifTrue: [^ self].  "no need to reinitialize"
	font _ newFont.
	spaceWidth _ font widthOf: Space. 
	sourceForm _ font glyphs.
	xTable _ font xTable.
	height _ font height.
	stopConditions _ font stopConditions.
	stopConditions at: Space asciiValue + 1 put: #space.
	stopConditions at: Tab asciiValue + 1 put: #tab.
	stopConditions at: CR asciiValue + 1 put: #cr.
	stopConditions at: EndOfRun put: #endOfRun.
	stopConditions at: CrossedX put: #crossedX