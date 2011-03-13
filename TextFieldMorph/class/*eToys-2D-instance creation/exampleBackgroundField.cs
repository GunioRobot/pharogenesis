exampleBackgroundField
	"Answer a scrollable background field for a parts bin"

	| aMorph |
	aMorph := self authoringPrototype.
	aMorph contents: 'background field' asText allBold.
	aMorph setProperty: #shared toValue: true.
	aMorph setNameTo: 'scrollingField1'.
	aMorph setProperty: #holdsSeparateDataForEachInstance toValue: true.
	^ aMorph