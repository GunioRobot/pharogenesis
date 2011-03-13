tabPanelBorderStyleFor: aTabPanel
	"Answer the normal border style for a tab panel."

	| aStyle |
	aStyle := BorderStyle complexRaised.
	aStyle width: 2.
	aStyle color: self backgroundColor.
	^aStyle.