grayColorsFor: d
	"return a color table for a gray image"

	| colors |
	colors _ Array new: 1<<d.
	d = 1 ifTrue: [
		colors at: 1 put: Color black.
		colors at: 2 put: Color white.
		^ colors
		].
	d = 2 ifTrue: [
		colors at: 1 put: Color black.
		colors at: 2 put: (Color gray: 0.3333).
		colors at: 3 put: (Color gray: 0.6667).
		colors at: 4 put: Color white.
		^ colors.
		].
	d = 4 ifTrue: [
		0 to: 15 do: [ :g |
			colors at: g+1 put: (Color gray: (g/15) asFloat) ].
		^ colors
		].
	d = 8 ifTrue: [
		0 to: 255 do: [ :g |
			colors at: g+1 put: (Color gray: (g/255) asFloat) ].
		^ colors
		].
