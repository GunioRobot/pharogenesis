setLabelStyle
	| aFont |
	"StandardSystemView setLabelStyle"
	aFont _ Preferences windowTitleFont.
	LabelStyle _ aFont textStyle copy consistOnlyOf: aFont.
	LabelStyle gridForFont: 1 withLead: 0