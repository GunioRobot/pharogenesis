translateBy: delta during: aBlock
	"Set a translation only during the execution of aBlock."
	| tempCanvas |
	tempCanvas _ self copyOffset: delta.
	aBlock value: tempCanvas.
	foundMorph _ tempCanvas foundMorph.