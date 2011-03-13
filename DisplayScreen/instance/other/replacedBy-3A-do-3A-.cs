replacedBy: aForm do: aBlock
	"Permits normal display to draw on aForm instead of the display."

	ScreenSave _ self.
	Display _ aForm.
	aBlock value.
	Display _ self.
	ScreenSave _ nil.