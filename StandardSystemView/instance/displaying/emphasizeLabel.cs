emphasizeLabel
	"Highlight the label."
	labelFrame height = 0 ifTrue: [^ self].  "no label"
	self displayLabelBackground: true.
	self displayLabelBoxes.
	self displayLabelText.