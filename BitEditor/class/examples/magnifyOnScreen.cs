magnifyOnScreen
	"Bit editing of an area of the display screen. User designates a 
	rectangular area that is magnified by 8 to allow individual screens dots to
	be modified. red button is used to set a bit to black and yellow button is
	used to set a bit to white. Editor is not scheduled in a view. Original
	screen location is updated immediately. This is the same as FormEditor
	magnify."
	| smallRect smallForm scaleFactor tempRect |
	scaleFactor := 8 @ 8.
	smallRect := Rectangle fromUser.
	smallRect isNil ifTrue: [^self].
	smallForm := Form fromDisplay: smallRect.
	tempRect := self locateMagnifiedView: smallForm scale: scaleFactor.
	"show magnified form size until mouse is depressed"
	self
		openScreenViewOnForm: smallForm 
		at: smallRect topLeft 
		magnifiedAt: tempRect topLeft 
		scale: scaleFactor

	"BitEditor magnifyOnScreen."