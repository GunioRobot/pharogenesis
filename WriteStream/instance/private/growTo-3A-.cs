growTo: anInteger

   " anInteger is the required minimal new size of the collection "
	| oldSize grownCollection newSize |
	oldSize _ collection size.
     newSize := anInteger + (oldSize // 4 max: 20).
	grownCollection _ collection class new: newSize.
	collection _ grownCollection replaceFrom: 1 to: oldSize with: collection startingAt: 1.
	writeLimit _ collection size.
