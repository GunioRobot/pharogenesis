nominalForm: aForm
	"Ascribe the blank nominal form"

	originalForm _ aForm.
	self rotationCenter: 0.5@0.5.
	self layoutChanged
