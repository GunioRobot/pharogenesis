simplePressurePen
	"An example of using a pressure sensitive pen to control the thickness of the pen. This requires the optional tablet support primitives which may not be supported on all platforms. Works best in full screen mode. Shift-mouse to exit."
	"Pen simplePressurePen"
	| tabletScale pen pressure p |
	tabletScale := self tabletScaleFactor.
	pen := Pen newOnForm: Display.
	pen color: Color black.
	Display fillColor: Color white.
	Display restoreAfter: 
		[ [ Sensor shiftPressed and: [ Sensor anyButtonPressed ] ] whileFalse: 
			[ p := (Sensor tabletPoint * tabletScale) rounded.
			pressure := (15.0 * Sensor tabletPressure) rounded.
			pressure > 0 
				ifTrue: 
					[ pen roundNib: pressure.
					pen goto: p ]
				ifFalse: [ pen place: p ] ] ]