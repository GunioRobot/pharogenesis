deEmphasizeView 
	"This window is becoming inactive."

	self topView cacheBitsAsTwoTone ifTrue: [
		"draw deEmphasized as a two-tone (monochrome) form"
		model displayWorldAsTwoTone].
