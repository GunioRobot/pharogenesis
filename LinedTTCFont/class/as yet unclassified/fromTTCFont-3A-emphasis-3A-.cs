fromTTCFont: aTTCFont emphasis: code

	| inst |
	inst _ self new.
	inst ttcDescription: aTTCFont ttcDescription.
	inst pointSize: aTTCFont pointSize.
	inst recreateCache.
	inst emphasis: (aTTCFont emphasis bitOr: code).
	inst lineGlyph: (aTTCFont ttcDescription at: $_).

	^ inst.
