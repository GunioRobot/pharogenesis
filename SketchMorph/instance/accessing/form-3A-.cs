form: aForm

	originalForm _ aForm.
	rotationCenter _ aForm extent // 2.
	rotationDegrees _ 0.0.
	self layoutChanged.
