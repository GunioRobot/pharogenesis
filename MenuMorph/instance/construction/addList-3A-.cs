addList: listOfPairs
	"Add the given items to this menu, where each item is a pair (<string> <actionSelector>)."

	listOfPairs do:
		[:aPair | self add: aPair first action: aPair last].
