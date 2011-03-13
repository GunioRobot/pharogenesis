initialize
	"ColorPickerMorph initialize"

	ColorChart _ Color colorPaletteForDepth: 16 extent: 190@60.
	DragBox _  (11@0) extent: 9@8.
	RevertBox _ (ColorChart width - 20)@1 extent: 9@8.
	FeedbackBox _ (ColorChart width - 10)@1 extent: 9@8.
	TransparentBox _ DragBox topRight corner: RevertBox bottomLeft.

		ColorChart fillBlack: ((DragBox left - 1)@0 extent: 1@9).
		ColorChart fillBlack: ((TransparentBox left)@0 extent: 1@9).
		ColorChart fillBlack: ((FeedbackBox left - 1)@0 extent: 1@9).
		ColorChart fillBlack: ((RevertBox left - 1)@0 extent: 1@9).
		(Form dotOfSize: 5) displayOn: ColorChart at: DragBox center + (0@1).

	TransText _ (Form extent: 63@8 depth: 1   "Where there's a will there's a way..."
			fromArray: #(4194306 1024 4194306 1024 15628058 2476592640
					4887714 2485462016 1883804850 2486772764 4756618
					2485462016 4748474 1939416064 0 0)
			offset: 0@0).
	TransText _ ColorForm mappingWhiteToTransparentFrom: TransText
