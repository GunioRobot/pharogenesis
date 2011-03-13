showPalette
	"Show the 12x12x12 palette used in fromUser.
	Color new showPalette"

	 | c rect |
	"RGB display gives 12x12x12 cube to choose from"
	c _ Color new.		"modified in loop below"
	rect _ 0@0 extent: 5@5.	"modified in loop below"
	0 to: 11 do: [:r |
		0 to: 11 do: [:g |
			0 to: 11 do: [:b |
				c setRed: r green: g blue: b range: 11.
				rect left: (r*60) + (b*5); width: 5.
				rect top: (g*5); height: 5.
				Display fill: rect fillColor: c.
			].
		].
	].
