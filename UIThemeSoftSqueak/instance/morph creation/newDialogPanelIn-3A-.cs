newDialogPanelIn: aThemedMorph
	"Answer a new (main) dialog panel."

	^(super 
		newDialogPanelIn: aThemedMorph)
		roundedCorners: #(2 3) "only bottom edge"