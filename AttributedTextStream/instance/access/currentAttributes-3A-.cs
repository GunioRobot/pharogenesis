currentAttributes: newAttributes
	"set the current attributes"
	attributesChanged _ currentAttributes ~= newAttributes.
	currentAttributes _ newAttributes.
