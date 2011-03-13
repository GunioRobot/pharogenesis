windowLabelForText: aStringOrText
	"Answer the window label to use for the given text."

	^StringMorph new
		contents: aStringOrText;
		font: Preferences windowTitleFont emphasis: 1;
		shadowColor: Color white;
		shadowOffset: 1@1;
		hasDropShadow: true.