deEmphasizeView 
	"This window is becoming inactive."

	Cursor normal show.    "restore the normal cursor"
	model handsDo:          "free dependents links if any"
		[:h | h newKeyboardFocus: nil].
	model canvas: nil.		"free model's canvas to save space"
	model fullReleaseCachedState.
	self topView cacheBitsAsTwoTone ifTrue: [
		"draw deEmphasized as a two-tone (monochrome) form"
		model displayWorldAsTwoTone].
