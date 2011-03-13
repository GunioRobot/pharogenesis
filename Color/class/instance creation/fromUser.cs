fromUser
	"Displays a color palette using abstract colors, then waits for a mouse click. Try it at various display depths!"
	"Color fromUser"
	| save d c rect old new s p |
	d _ Display depth.
	((ColorChart == nil) or: [ColorChart depth ~= Display depth]) 
		ifTrue: [ColorChart _ self colorChartForDepth: d extent: 720@100].
	save _ Form fromDisplay: (0@0 extent: ColorChart extent).
	ColorChart displayAt: 0@0.

	old _ 0.
	[Sensor anyButtonPressed] whileFalse: [
		p _ Display pixelValueAt: Sensor cursorPoint.
		c _ self colorFromPixelValue: p depth: d.
		Display fill: (0@80 extent: 60@20) fillColor: c.
		(new _ p) = old ifFalse: [
			Display fillWhite: (60@80 extent: 180@20).
			s _ c printString.
			s _ 'R,G,B = ', (s copyFrom: 7 to: s size - 1).
			s displayAt: 63@83.
			old _ new.
		].
	].
	save displayAt: 0@0.
	Sensor waitNoButton.
	^ c
