magnify
	"Allow for bit editing of an area of the Form. The user designates a 
	rectangular area that is scaled by 5 to allow individual screens dots to be 
	modified. Red button is used to set a bit to black, and yellow button is 
	used to set a bit to white. Editing continues until the user depresses any 
	key on the keyboard."

	| smallRect smallForm scaleFactor tempRect |
	scaleFactor := 8@8.
	smallRect := (Rectangle fromUser: grid) intersect: view insetDisplayBox.
	smallRect isNil ifTrue: [^self].
	smallForm := Form fromDisplay: smallRect.

	"Do this computation here in order to be able to save the existing display screen."
	tempRect := BitEditor locateMagnifiedView: smallForm scale: scaleFactor.
	BitEditor
		openScreenViewOnForm: smallForm 
		at: smallRect topLeft 
		magnifiedAt: tempRect topLeft 
		scale: scaleFactor.
	tool := previousTool