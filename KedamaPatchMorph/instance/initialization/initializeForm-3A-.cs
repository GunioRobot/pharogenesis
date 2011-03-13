initializeForm: aForm 

	form _ aForm. 
	form fillColor: Color transparent.

	displayForm _ (Form extent: aForm extent depth: 32).
	tmpForm _ (Form extent: aForm extent depth: 32).
	tmpForm fillColor: Color black.

	super extent: form extent.
	self changed.
	self formChanged.
