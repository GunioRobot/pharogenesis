chooseColor
	"Displays a color palette using abstract colors, then waits for a mouse click."
	"Copied from Color fromUser, then shrunk. 4/16/97 tk"

	| loc d chartExtent transp save pt c feedbackColor |
	loc _ Sensor cursorPoint.
	d _ Display depth.
	chartExtent _ 216@56.
	((ColorChart == nil) or: [ColorChart depth ~= Display depth]) 
		ifTrue: [ColorChart _ Color oldColorPaletteForDepth: d extent: chartExtent].
	transp _ Rectangle origin: chartExtent - (50@19) + loc extent: 50@19.
	save _ Form fromDisplay: (loc extent: ColorChart extent).
	ColorChart displayAt: loc.

	Cursor normal showWhile: [
		[Sensor anyButtonPressed] whileFalse: [
			pt _ Sensor cursorPoint.
			c _ feedbackColor _ Display colorAt: pt.
			(transp containsPoint: pt) ifTrue: [
				c _ Color transparent.
				feedbackColor _ Color white].
			Display fill: (loc + (0@37) extent: 73@19) fillColor: feedbackColor].
		save displayAt: loc.
		Sensor waitNoButton].
	^ c
