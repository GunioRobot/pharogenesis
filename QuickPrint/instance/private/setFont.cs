setFont
	"Install various parameters from the font."
	spaceWidth _ font widthOf: Space. 
	sourceForm _ font glyphs.  "Should only be needed in DisplayScanner"
	height _ font height.			" ditto "
	xTable _ font xTable.
	stopConditions _ font stopConditions.
	stopConditions at: Space asciiValue + 1 put: nil.
	stopConditions at: Tab asciiValue + 1 put: #tab.
	stopConditions at: CR asciiValue + 1 put: #cr.
	stopConditions at: EndOfRun put: #endOfRun.
	stopConditions at: CrossedX put: #crossedX