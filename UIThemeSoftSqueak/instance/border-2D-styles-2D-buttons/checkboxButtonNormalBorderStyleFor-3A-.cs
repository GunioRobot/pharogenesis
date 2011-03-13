checkboxButtonNormalBorderStyleFor: aCheckboxButton
	"Return the normal checkbox button borderStyle for the given button."

	^BorderStyle inset
		width: 1;
		baseColor: aCheckboxButton paneColor darker