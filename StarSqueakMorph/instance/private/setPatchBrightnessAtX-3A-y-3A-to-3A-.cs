setPatchBrightnessAtX: x y: y to: percent 
	"Set the brightness of the patch at the given location to the given level, where 0 is black and 100 is full brightness."

	| c brightness |
	c := self getPatchColorAtX: x y: y.
	brightness := percent / 100.0.
	brightness := brightness max: 0.03125.
	self 
		setPatchColorAtX: x
		y: y
		to: (Color 
				h: c hue
				s: c saturation
				v: brightness)