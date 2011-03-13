redButtonActivity
	"Determine which item in the red button pop-up menu is selected. If one 
	is selected, then send the corresponding message to the object designated 
	as the menu message receiver."

	| index |
	redButtonMenu ~~ nil
		ifTrue: 
			[index := redButtonMenu startUp.
			index ~= 0 
				ifTrue: [self perform: (redButtonMessages at: index)]]
		ifFalse: [super controlActivity]