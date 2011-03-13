backgroundForm: aForm
	screenController view model: aForm.
	ScheduledControllers restore
"
	QDPen new mandala: 30 diameter: 640.
	ScheduledControllers backgroundForm:
		(Form fromDisplay: Display boundingBox).

	ScheduledControllers backgroundForm:
		(InfiniteForm with: Form gray).
"