standardSlotInfo
	^ #((numericValue 	number		readWrite	getNumericValue	setNumericValue:)
		(minVal			number		readWrite	getMinVal			setMinVal:)
		(maxVal			number		readWrite	getMaxVal			setMaxVal:)
		(descending		boolean		readWrite	getDescending		setDescending:)
		(truncate		boolean		readWrite	getTruncate			setTruncate:)
		(knobColor		color		readWrite	getKnobColor		setKnobColor:))
