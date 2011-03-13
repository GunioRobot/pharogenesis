initializeForm: aForm
	originalForm := aForm.
	rotatedForm := originalForm.	"cached rotation of originalForm"
	self extent: originalForm extent.
