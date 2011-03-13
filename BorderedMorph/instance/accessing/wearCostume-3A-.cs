wearCostume: anotherMorph
	"Modify the receiver so that it resembles anotherMorph"

	super wearCostume: anotherMorph.
	self setBorderWidth: anotherMorph borderWidth borderColor: anotherMorph borderColor
