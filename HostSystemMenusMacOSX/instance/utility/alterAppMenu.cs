alterAppMenu 
	| fileMenu items menu |	
	fileMenu := self getMenuHandle: 1.
	items := self buildSubMenusFor: World worldMenu  systemMenu.
	items at: 3 put: (HostSystemMenusMenuItem subMenu: 201 menuString: 'Preferences...').
	
	items add: (HostSystemMenusMenuItem menuString: '-');
		add: (HostSystemMenusMenuItem menuString: 'Save' 
				handler: [:evt | SmalltalkImage current snapshot: true andQuit: false ]);
		add: (HostSystemMenusMenuItem menuString: 'Save As...' 
				handler: [:evt | SmalltalkImage current saveAs]);
		add: (HostSystemMenusMenuItem menuString: 'Save and Quit' 
				handler: [:evt | SmalltalkImage current snapshot: true andQuit: true]).
	self appendMenu: fileMenu menuItems: items.
		
	
	items := self buildSubMenusFor: World worldMenu  appearanceMenu.
	items at: 2 put: (HostSystemMenusMenuItem subMenu: 202 menuString: 'System fonts...').
	menu := self newMenu: 201 menuTitle: 'appearanceDo'.
	self insertMenu: menu beforeID: -1.
	self appendMenu: menu menuItems: items.
	
	items := self buildSubMenusFor: Preferences fontConfigurationMenu.
	menu := self newMenu: 202 menuTitle: 'SystemFonts'.
	self insertMenu: menu beforeID: -1.
	self appendMenu: menu menuItems: items.