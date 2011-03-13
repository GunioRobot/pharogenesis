newLabelGroupSpread: labelsAndControls
	"Answer a morph laid out with a column of labels and a column of associated controls."

	^self theme
		newLabelGroupIn: self
		for: labelsAndControls
		spaceFill: true