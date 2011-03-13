testMenuHandlesNewMenuAppendCheckSetMark

	self testMenuHandlesNewMenuAppend.
	interface setItemMark: secondaryMenu item: 1 markChar: $x.
	self should: [(interface getItemMark: secondaryMenu item: 1) = $x].



	

