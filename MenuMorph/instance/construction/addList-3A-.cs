addList: listOfPairs
	"Add the given items to this menu, where each item is a pair (<string> <actionSelector>)..  ILf an element of the list is simply the symobl $-, add a line to the receiver."

	listOfPairs do: [:pair |
		#- = pair
			ifTrue: [self addLine]
			ifFalse: [self add: pair first action: pair last]]