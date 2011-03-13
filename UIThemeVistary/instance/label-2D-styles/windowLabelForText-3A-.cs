windowLabelForText: aStringOrText
	"Answer the window label to use for the given text."

	^FuzzyLabelMorph new
		contents: aStringOrText;
		font: Preferences windowTitleFont emphasis: 1