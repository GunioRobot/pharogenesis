testMenuHandlesNewMenuAppend2
	|  menuString items testArray |
	menuString := 'Foobar'.
	secondaryMenu := interface newMenu: self notUsedMenuNumber2 menuTitle: menuString.
	interface insertMenu: secondaryMenu beforeID: 0.
	items := OrderedCollection new.
	items add:  (HostSystemMenusMenuItem menuString: 'one').
	items add:  (HostSystemMenusMenuItem menuString: 'two').
	items add:  (HostSystemMenusMenuItem menuString: 'three').
	items add:  (HostSystemMenusMenuItem menuString: 'four').
	items add:  (HostSystemMenusMenuItem menuString: 'five').
	items add:  (HostSystemMenusMenuItem menuString: 'six').
	(items at: 1) styleAdd: #bold.
	(items at: 2) styleAdd: #italic.
	(items at: 3) styleAdd: #underline.
	(items at: 4) styleAdd: #outline.
	(items at: 5) styleAdd: #shadow.
	(items at: 6) styleAdd: #bold.
	(items at: 6) styleAdd: #italic.
	(items at: 6) styleAdd: #underline.
	(items at: 6) styleAdd: #outline.
	(items at: 6) styleAdd: #shadow.
	interface appendMenu: secondaryMenu menuItems: items.
	testArray := #(1 #bold 2 #italic 3 #underline 4 #outline 5 #shadow).
	testArray pairsDo: [:item :style |
		self should: [(interface getItemStyle: secondaryMenu item: item) size = 1].
		self should: [(interface getItemStyle: secondaryMenu item: item) includes: style]].
	testArray := #(6 #bold 6 #italic 6 #underline 6 #outline 6 #shadow).
	self should: [(interface getItemStyle: secondaryMenu item: 6) size = 5].
	testArray pairsDo: [:item :style |
		self should: [(interface getItemStyle: secondaryMenu item: item) includes: style]].
	

	



	

