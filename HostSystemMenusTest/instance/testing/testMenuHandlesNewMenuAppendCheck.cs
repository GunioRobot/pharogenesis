testMenuHandlesNewMenuAppendCheck

	self testMenuHandlesNewMenuAppend.
	self should: [(interface getItemMark: secondaryMenu item: 1)  = 0 asCharacter].
	interface checkMenuItem: secondaryMenu item: 1 checked: true.
	self should: [(interface getItemMark: secondaryMenu item: 1)  = 18 asCharacter].
	interface checkMenuItem: secondaryMenu item: 1 checked: false.
	self should: [(interface getItemMark: secondaryMenu item: 1)  = 0 asCharacter].



	

