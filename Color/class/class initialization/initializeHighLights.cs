initializeHighLights
	"Special set of very fast colors (Bitmaps) for highlighting text and areas without converting colors. 6/22/96 tk
	Color initializeHighLights"

"A default color that will at least reverse most bits"
| v |
HighLightBitmaps _ Array new: 32.
#(1 2 4 8 16 32) do: [:depth |
	v _ depth <= 8
		ifTrue: [self new pixelValue: (#(1 3 0 5 0 0 0 8) at: depth)
					toBitPatternDepth: depth]
		ifFalse: [Bitmap with: 16rFFFFFFFF].
	HighLightBitmaps at: depth put: v].