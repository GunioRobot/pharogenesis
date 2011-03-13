openOnForm: aForm 
	"Create and schedule a BitEditor on the form aForm at its top left corner. 
	Show the small and magnified view of aForm."

	| scaleFactor |
	scaleFactor := 8 @ 8.
	^self openOnForm: aForm
		at: (self locateMagnifiedView: aForm scale: scaleFactor) topLeft
		scale: scaleFactor