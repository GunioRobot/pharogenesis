simplePressurePen
	"An example of using a pressure sensitive pen to control the thickness of the pen. This requires the optional tablet support primitives which may not be supported on all platforms. Works best in full screen mode. Shift-mouse to exit." 
	"Pen simplePressurePen"

	| tabletScale pen pressure p |
	tabletScale _ self tabletScaleFactor.
	pen _ Pen newOnForm: Display.
	pen color: Color black.
	Display fillColor: Color white.
	Display restoreAfter: [
		[Sensor shiftPressed and: [Sensor anyButtonPressed]] whileFalse: [
			p _ (Sensor tabletPoint * tabletScale) rounded.
			pressure _ (15.0 * Sensor tabletPressure) rounded.
		     pressure > 0
				ifTrue: [
					pen roundNib: pressure.
					pen goto: p]
				ifFalse: [
					pen place: p]]].
