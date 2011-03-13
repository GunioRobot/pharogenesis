uiThemeRadioButtons
	"Answer a column of butons representing the choices of ui theme"

	| buttonColumn |
	buttonColumn := self verticalPanel.
	self allThemeClasses do: [:c |
		buttonColumn addMorphBack: (self newRadioButtonFor: c)].
	^buttonColumn