testMenuHandlesNewMenuAppendCheckSetCmd

	self testMenuHandlesNewMenuAppend.
	interface setItemCmd: secondaryMenu item: 1 cmdChar: $x.
	self should: [(interface getItemCmd: secondaryMenu item: 1) = $x].



	

