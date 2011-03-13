showHuesAtSaturation: s brightness: v
	"Shows a palette of hues at the given (saturation, brightness) point."
	"Color new showHuesAtSaturation: 0.9 brightness: 0.9"

	| rect c |
	rect _ 0@0 extent: 5@5.	"modified in loop below"
	0 to: 179 by: 10 do: [:h |
		c _ Color hue: h saturation: s brightness: v.
		rect left: 5 + (h*4); width: 35.
		rect top: 5; height: 35.
		Display fill: rect fillColor: c.

		c setHue: h + 180 saturation: s brightness: v.
		rect top: 45; height: 35.
		Display fill: rect fillColor: c.
	].
