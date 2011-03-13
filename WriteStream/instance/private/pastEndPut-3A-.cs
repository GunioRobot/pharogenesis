pastEndPut: anObject
	"Grow the collection by creating a new bigger collection and then
	copy over the contents from the old one. We grow by doubling the size
	but the growth is kept between 20 and 1000000.
	Finally we put <anObject> at the current write position."

	| oldSize grownCollection |
	oldSize := collection size.
	grownCollection := collection class new: oldSize + ((oldSize max: 20) min: 1000000).
	collection := grownCollection replaceFrom: 1 to: oldSize with: collection startingAt: 1.
	writeLimit := collection size.
	collection at: (position := position + 1) put: anObject.
	"return the argument - added by kwl"
	^ anObject