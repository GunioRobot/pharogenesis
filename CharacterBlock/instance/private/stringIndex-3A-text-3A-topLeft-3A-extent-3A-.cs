stringIndex: anInteger text: aText topLeft: topLeft extent: extent 
	stringIndex := anInteger.
	text := aText.
	super 
		setOrigin: topLeft
		corner: topLeft + extent