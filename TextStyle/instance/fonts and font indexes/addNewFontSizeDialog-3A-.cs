addNewFontSizeDialog: args
	"This is called from a modal menu and call back the menu with entered argument."
	| f n r |
	f _ FillInTheBlank request: 'Enter the point size' initialAnswer: '12'.
	n _ f asNumber.
	r _ self addNewFontSize: n.
	r ifNotNil: [
		args second ifNotNil: [args second modalSelection: {args first. n}].
	].
