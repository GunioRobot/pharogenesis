deEmphasizeLabel
	"Un-Highlight the label."
	labelFrame height = 0 ifTrue: [^ self].  "no label"
	self displayLabelBackground: false.
	self displayLabelText.