allColorsForDepth: d
	"Return the colorMap for the depth.  Use a ColorGenerator to simulate a very big Array for 16 and 32.  6/22/96 tk"

	d < 16 ifTrue: [^ IndexedColors copyFrom: 1 to: (1 bitShift: d)].
	^ ColorGenerator new depth: d