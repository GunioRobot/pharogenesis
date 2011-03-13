newLabelGroup: labelsAndControls font: aFont labelColor: aColor
	"Answer a morph laid out with a column of labels and a column of associated controls."

	^self theme
		newLabelGroupIn: self
		for: labelsAndControls
		spaceFill: false
		font: aFont
		labelColor: aColor
