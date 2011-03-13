displayLabelText
	"The label goes in the center of the window"
	labelText foregroundColor: self foregroundColor
			backgroundColor: self labelColor;
		displayOn: Display at: self labelTextRegion topLeft.
