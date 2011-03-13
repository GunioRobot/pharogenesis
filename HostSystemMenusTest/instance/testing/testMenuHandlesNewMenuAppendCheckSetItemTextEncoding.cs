testMenuHandlesNewMenuAppendCheckSetItemTextEncoding
	| encoding |
	self testMenuHandlesNewMenuAppend.
	encoding := 37.
	interface setMenuItemTextEncoding: secondaryMenu item: 1 inScriptID: encoding.
	self should: [(interface getMenuItemTextEncoding: secondaryMenu item: 1) = encoding].



	

