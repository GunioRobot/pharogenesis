hideCursor: evt
	"Set the cursor back."
	evt hand showTemporaryCursor: nil
		hotSpotOffset: 0@0.	"back to normal"
