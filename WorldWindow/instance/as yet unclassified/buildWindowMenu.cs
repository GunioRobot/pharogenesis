buildWindowMenu

	| aMenu |
	aMenu _ super buildWindowMenu.
	{640@480. 800@600. 832@624. 1024@768} do: [ :each |
		aMenu 
			add: each x printString,' x ',each y printString 
			target: self 
			selector: #extent: 
			argument: each + (0@self labelHeight).
	].
	^aMenu