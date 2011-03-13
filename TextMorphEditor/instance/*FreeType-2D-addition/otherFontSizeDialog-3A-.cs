otherFontSizeDialog: args
	"This is called from a modal menu and call back the menu with entered argument."
	| f n |
	f := UIManager default request: 'Enter the point size' initialAnswer: '12'.
	f ifNil: [f := String new].
	n := f asNumber.
	args second ifNotNil: [args second modalSelection: {args first. n}]