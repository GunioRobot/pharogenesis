fromUser
	"Displays a color palette of colors, waits for a mouse click, and returns the selected color. Any pixel on the Display can be chosen, not just those in the color palette."
	"Note: Since the color chart is cached, you may need to do 'ColorChart _ nil' after changing the oldColorPaletteForDepth:extent: method."
	"Color fromUser"

	| d startPt save tr oldColor c here s |
	d _ Display depth.
	((ColorChart == nil) or: [ColorChart depth ~= Display depth]) 
		ifTrue: [ColorChart _ self oldColorPaletteForDepth: d extent: (2 * 144)@80].
	Sensor cursorPoint y < Display center y 
		ifTrue: [startPt _ 0@(Display boundingBox bottom - ColorChart height)]
		ifFalse: [startPt _ 0@0].

	save _ Form fromDisplay: (startPt extent: ColorChart extent).
	ColorChart displayAt: startPt.
	tr _ ColorChart extent - (50@19) corner: ColorChart extent.
	tr _ tr translateBy: startPt.

	oldColor _ nil.
	[Sensor anyButtonPressed] whileFalse: [
		c _ Display colorAt: (here _ Sensor cursorPoint).
		(tr containsPoint: here)
			ifFalse: [Display fill: (0@61+startPt extent: 20@19) fillColor: c]
			ifTrue: [
				c _ Color transparent.
				Display fill: (0@61+startPt extent: 20@19) fillColor: Color white].
		c = oldColor ifFalse: [
			Display fillWhite: (20@61 + startPt extent: 135@19).
			c isTransparent
				ifTrue: [s _ c shortPrintString]
				ifFalse: [
					s _ c shortPrintString.
					s _ s copyFrom: 7 to: s size - 1].
			s displayAt: 20@61 + startPt.
			oldColor _ c]].
	save displayAt: startPt.
	Sensor waitNoButton.
	^ c
