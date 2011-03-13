initializeWithBuffer: aBuffer form: aForm
	isBuffer := true.
	buffer := aBuffer.
	self initialize: aBuffer.
	self form: aForm.
	^self