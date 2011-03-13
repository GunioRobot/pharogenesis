testMenuHandlesNewMenuAppendCheckSetCmd2

	(SmalltalkImage current osVersion asNumber < 1000) 
		ifTrue: [^self].
	self testMenuHandlesNewMenuAppend.
	interface setMenuItemCommandID: secondaryMenu item: 1 menuCommand: 120.
	self should: [(interface getMenuItemCommandID: secondaryMenu item: 1) = 120].



	

