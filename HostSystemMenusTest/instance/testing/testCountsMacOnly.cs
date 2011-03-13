testCountsMacOnly
	"Mac test, check state of Menus installed by VM and by menu initialization counts are platform dependent"

	self isMacintosh ifFalse: [^self].
	(SmalltalkImage current  osVersion asNumber >= 1000) 
		ifTrue: 
			[self should: [(interface countMenuItems: (interface getMenuHandle: self applicationFirstMenu)) = 7]]
		ifFalse: 
			[self should: [(interface countMenuItems: (interface getMenuHandle: self applicationFirstMenu)) > 0].
			self should: [(interface countMenuItems: (interface getMenuHandle: self fileMenu)) = 6]].
	self should: [(interface countMenuItems: (interface getMenuHandle: self editMenu)) = 6].

