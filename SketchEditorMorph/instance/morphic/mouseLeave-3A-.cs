mouseLeave: evt
	"Set the cursor."

	super mouseLeave: evt.
	evt hand showTemporaryCursor: nil
		hotSpotOffset: 0@0.	"back to normal"
	"If this is modified to close down the SketchEditorMorph in any way, watch out for how it is called when entering a rotationButton and a scaleButton."