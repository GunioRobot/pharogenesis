initialize
	outputStream _ AttributedTextStream new.
	preformattedLevel _ 0.
	indentLevel _ boldLevel _ italicsLevel _ underlineLevel _ strikeLevel _ centerLevel _ 0.
	listLengths _ OrderedCollection new.
	listTypes _ OrderedCollection new.
	formDatas _ OrderedCollection new.
	precedingSpaces _ 0.
	precedingNewlines _ 1000.   "more than will ever be asked for"
	morphsToEmbed _ OrderedCollection new.
	incompleteMorphs _ OrderedCollection new.
	anchorLocations _ Dictionary new.
	imageMaps _ OrderedCollection new.