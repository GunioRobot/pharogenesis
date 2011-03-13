indentationLevel: anInteger
	super indentationLevel: anInteger.
	nextLeftMargin _ leftMargin.
	indentationLevel timesRepeat: [
		nextLeftMargin _ textStyle nextTabXFrom: nextLeftMargin
					leftMargin: leftMargin
					rightMargin: rightMargin]