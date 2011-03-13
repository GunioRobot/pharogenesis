test: depth
	"Color new test: 8"

	| i c |
	1 to: (1 << depth) do: [ :i |
		c _ IndexedColors at: i.
		(Color colorFromPixelValue: (c pixelValueForDepth: depth) value depth: depth) = c
			ifFalse: [ self error: 'bad conversion' ].
	].