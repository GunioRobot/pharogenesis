centerLabel
	"If there is a label, align its center with the center of the insetDisplayBox"

	label ifNotNil: 
		[self centerAlignLabelWith: self insetDisplayBox center].
