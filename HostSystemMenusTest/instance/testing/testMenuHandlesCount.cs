testMenuHandlesCount
	(SmalltalkImage current   osVersion asNumber >= 1000) ifTrue: 
		[self should: [(interface countMenuItems: (interface getMenuHandle: 1)) = 7]]
		ifFalse: 
			[self should: [(interface countMenuItems: (interface getMenuHandle: 1)) > 0]].
	self should: [(interface countMenuItems: (interface getMenuHandle: 3)) = 6].

