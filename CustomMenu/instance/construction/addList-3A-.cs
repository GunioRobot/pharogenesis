addList: listOfPairs
	"Treating the input parameter as a list of the form (<what to show> <selector>), add items to the receiver for each pair"

	listOfPairs do:
		[:aPair | self add: aPair first action: aPair last]