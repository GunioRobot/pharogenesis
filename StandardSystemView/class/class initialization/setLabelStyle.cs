setLabelStyle
	| aFont |
	"StandardSystemView setLabelStyle"
	aFont _ Preferences windowTitleFont.
	LabelStyle _ TextStyle fontArray: { aFont }.
	LabelStyle gridForFont: 1 withLead: 0