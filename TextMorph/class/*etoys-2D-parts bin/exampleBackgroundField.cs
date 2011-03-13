exampleBackgroundField
	"Answer a background field for a parts bin"

	| aMorph |
	aMorph := TextMorph authoringPrototype.
	aMorph contents: 'background field' asText allBold.
	aMorph setProperty: #shared toValue: true.
	aMorph setNameTo: 'field1'.
	aMorph setProperty: #holdsSeparateDataForEachInstance toValue: true.	
	^ aMorph
