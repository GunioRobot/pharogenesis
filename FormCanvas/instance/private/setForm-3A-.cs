setForm: aForm

	self reset.
	form _ aForm.
	port _ self portClass toForm: form.
