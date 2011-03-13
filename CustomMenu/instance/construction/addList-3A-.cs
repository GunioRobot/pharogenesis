addList: listOfPairs
	"Add a menu item to the receiver for each pair in the given list of the form (<what to show> <selector>). Add a line for each dash (-) in the list."
	"CustomMenu new addList: #(
		('apples' buyApples)
		('oranges' buyOranges)
		-
		('milk' buyMilk)); startUp"

	listOfPairs do: [:pair |
		#- = pair
			ifTrue: [self addLine]
			ifFalse: [self add: pair first action: pair last]].
