frameRectangle: r width: w color: c
	"Draw a frame around the given rectangle"
	^self frameAndFillRectangle: r
			fillColor: nil
			borderWidth: w
			borderColor: c