fullDrawPostscriptOn: aCanvas

	| f |
	"handle the fact that we have the squished text within"

	f _ self imageForm.
	f offset: 0@0.
	aCanvas paintImage: f at: bounds origin.
