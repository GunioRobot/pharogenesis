alphabeticTabs
	"Answer a list of buttons which, when hit, will trigger the choice of a morphic category"

	| buttonList aButton tabLabels |
	tabLabels _ (($a to: $z) collect: [:ch | ch asString]) asOrderedCollection.

	buttonList _ tabLabels collect:
		[:catName |
			aButton _ SimpleButtonMorph new label: catName.
			aButton actWhen: #buttonDown.
			aButton target: self; actionSelector: #showAlphabeticCategory:fromButton:; arguments: {catName. aButton}].
	^ buttonList

"ObjectsTool new tabsForMorphicCategories"