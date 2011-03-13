checkboxButtonDisabledBorderStyleFor: aCheckboxButton
	"Return the disabled checkbox button borderStyle for the given button."

	^BorderStyle inset
		width: 1;
		baseColor: aCheckboxButton paneColor darker