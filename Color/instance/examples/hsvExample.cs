hsvExample
	"Shows a palette of hues, varying the saturation and brightness for each one."
	"Color new hsvExample.  Modified 6/14/96 tk"

	| d v x y c rect |
	d _ Display depth.
	c _ Color new.		"modified in loop below"
	rect _ 0@0 extent: 5@5.	"modified in loop below"
	0 to: 179 by: 15 do: [:h |
		0 to: 10 do: [:s |
			0 to: 10 do: [:v |
				c setHue: h saturation: s asFloat / 10.0 brightness: v asFloat / 10.0.
				rect left: (h*4) + (s*5); width: 5.
				rect top: (v*5); height: 5.
				Display fill: rect fillColor: (c bitPatternForDepth: d).

				c setHue: h + 180 saturation: s asFloat / 10.0 brightness: v asFloat / 10.0.
				rect top: (v*5) + 80; height: 5.
				Display fill: rect fillColor: (c bitPatternForDepth: d).
			].
		].
	].
