testMenuHandlesNewMenuAppendCheckSetStyle
	| styles |
	
	self testMenuHandlesNewMenuAppend.
	styles := Set withAll: #( #bold #italic #underline #outline #shadow).
	interface setItemStyle: secondaryMenu item: 1 style: styles.
	self should: [(interface getItemStyle: secondaryMenu item: 1) size = 5].
	styles do: [:style |
		self should: [(interface getItemStyle: secondaryMenu item: 1) includes: style]].



	

