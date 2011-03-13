setLabelStyle
	| aFont |
	"StandardSystemView setLabelStyle"
	aFont := Preferences windowTitleFont.
	LabelStyle := TextStyle fontArray: { aFont }.
	LabelStyle gridForFont: 1 withLead: 0