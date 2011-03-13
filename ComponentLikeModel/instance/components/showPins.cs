showPins
	"Make up sensitized pinMorphs for each of my interface variables"
	self pinSpecs do: [:pinSpec | self addPinFromSpec: pinSpec]