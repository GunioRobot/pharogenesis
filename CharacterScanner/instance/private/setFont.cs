setFont
	"Set the font and other emphasis."
	self setFont: 1.
	emphasisCode _ 0.
	kern _ 0.
	(text attributesAt: lastIndex) do: 
		[:att | att emphasizeScanner: self].
	font _ font emphasized: emphasisCode.

	"Install various parameters from the font."
	spaceWidth _ font widthOf: Space. 
	sourceForm _ font glyphs.  "Should only be needed in DisplayScanner"
	height _ font height.			" ditto "
	xTable _ font xTable.
	stopConditions _ font stopConditions.
	stopConditions at: Space asciiValue + 1 put: #space.
	stopConditions at: Tab asciiValue + 1 put: #tab.
	stopConditions at: CR asciiValue + 1 put: #cr.
	stopConditions at: EndOfRun put: #endOfRun.
	stopConditions at: CrossedX put: #crossedX