initializeIndexedColors
	"Build an array of colors corresponding to the fixed colormap used
	 for display depths of 1, 2, 4, or 8 bits."
	"Color initializeIndexedColors"

	| a index grayVal |
	a _ Array new: 256.

	"1-bit colors (monochrome)"
	a at: 1 put: (self red: 1.0 green: 1.0 blue: 1.0).  "white"
	a at: 2 put: (self red: 0.0 green: 0.0 blue: 0.0).  "black"

	"additional colors for 2-bit color"
	a at: 3 put: (self red: 0.5 green: 0.5 blue: 0.5).  "50% gray"
	a at: 4 put: (self red: 1.0 green: 1.0 blue: 0.0).  "yellow"

	"additional colors for 4-bit color"
	a at: 5 put: (self red: 1.0 green: 0.0 blue: 0.0).  "red"
	a at: 6 put: (self red: 0.0 green: 1.0 blue: 0.0).  "green"
	a at: 7 put: (self red: 0.0 green: 0.0 blue: 1.0).  "blue"
	a at: 8 put: (self red: 0.0 green: 1.0 blue: 1.0).  "cyan"
	a at: 9 put: (self red: 1.0 green: 0.0 blue: 1.0).  "magenta"

	a at: 10 put: (self red: 0.125 green: 0.125 blue: 0.125).	"1/8 gray"
	a at: 11 put: (self red: 0.25 green: 0.25 blue: 0.25).		"2/8 gray"
	a at: 12 put: (self red: 0.375 green: 0.375 blue: 0.375).	"3/8 gray"
	a at: 13 put: (self red: 0.50 green: 0.50 blue: 0.50).		"4/8 gray"
	a at: 14 put: (self red: 0.625 green: 0.625 blue: 0.625).	"5/8 gray"
	a at: 15 put: (self red: 0.75 green: 0.75 blue: 0.75).		"6/8 gray"
	a at: 16 put: (self red: 0.875 green: 0.875 blue: 0.875).	"7/8 gray"

	"additional colors for 8-bit color"
	"24 more shades of gray (1/32 increments but not repeating 1/8 increments)"
	index _ 17.
	1 to: 31 do: [ :v |
		(v \\ 4) = 0 ifFalse: [
			grayVal _ v / 32.0.
			a at: index put: (self red: grayVal green: grayVal blue: grayVal).
			index _ index + 1.
		].
	].

	"The remainder of color table defines a color cube with six steps
	 for each primary color. Note that the corners of this cube repeat
	 previous colors, but this simplifies the mapping between RGB colors
	 and color map indices. This color cube spans indices 40 through 255
	 (indices 41-256 in this 1-based array)."

	0 to: 5 do: [ :r |
		0 to: 5 do: [ :g |
			0 to: 5 do: [ :b |
				index _ 41 + ((36 * r) + (6 * b) + g).
				index > 256 ifTrue: [
					self error: 'index out of range in color table compuation'.
				].
				a at: index put:
					(self red: r green: g blue: b range: 5).
			].
		].
	].

	IndexedColors _ a.