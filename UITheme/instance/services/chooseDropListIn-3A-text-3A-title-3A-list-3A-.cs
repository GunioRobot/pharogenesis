chooseDropListIn: aThemedMorph text: aStringOrText title: aString list: aList
	"Answer the result of a drop list chooser with the given label, title and list."

	^(aThemedMorph openModal: (
		ChooseDropListDialogWindow new
			textFont: self textFont;
			title: aString;
			text: aStringOrText;
			list: aList)) selectedItem