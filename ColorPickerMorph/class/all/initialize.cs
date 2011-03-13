initialize
	"ColorPickerMorph initialize"

	ColorChart _ Color colorPaletteForDepth: 16 extent: 190@60.
	TransparentBox _ ColorChart boundingBox withHeight: 10.
	FeedbackBox _ (ColorChart width - 20)@0 extent: 20@9.
