tabLabelNormalBorderStyleFor: aTabLabel
	"Answer the normal border style for a tab label."

	| aStyle |
	aStyle := W2KComplexTabBorder new.
	aStyle width: 1.
	aStyle color: self backgroundColor.
	^aStyle.