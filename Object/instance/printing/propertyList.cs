propertyList
	"Answer a String whose characters are a property-list description of the receiver."

	^ PropertyListEncoder process:self.
