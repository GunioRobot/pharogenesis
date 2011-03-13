enabled
	"Answer whether the receiver is enabled for user input."

	^self sliderMorph
		ifNil: [super enabled]
		ifNotNilDo: [:sm | sm enabled]