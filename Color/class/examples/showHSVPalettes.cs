showHSVPalettes
	"Shows a palette of hues, varying the saturation and brightness for each one. Best results are with depths 16 and 32."
	"Color showHSVPalettes"

	| left top c |
	left _ top _ 0.
	0 to: 179 by: 15 do: [:h |
		0 to: 10 do: [:s |
			left _ (h * 4) + (s * 4).
			0 to: 10 do: [:v |
				c _ Color h: h s: s asFloat / 10.0 v: v asFloat / 10.0.
				top _ (v * 4).
				Display fill: (left@top extent: 4@4) fillColor: c.

				c _ Color h: h + 180 s: s asFloat / 10.0 v: v asFloat / 10.0.
				top _ (v * 4) + 50.
				Display fill: (left@top extent: 4@4) fillColor: c]]].
