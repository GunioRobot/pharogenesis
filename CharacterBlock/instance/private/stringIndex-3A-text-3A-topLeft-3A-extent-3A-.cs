stringIndex: anInteger text: aText topLeft: topLeft extent: extent

	stringIndex _ anInteger.
	text _ aText.
	super setOrigin: topLeft corner: topLeft + extent 