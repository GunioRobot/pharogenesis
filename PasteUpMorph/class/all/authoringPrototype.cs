authoringPrototype
	"Answer an instance of the receiver suitable for placing in a parts bin for authors"
	
	| proto |
	proto _ self new markAsPartsDonor.
	proto color: Color green muchLighter; borderWidth: 2; 
		borderColor: Color green; extent: 100@80.
	^ proto