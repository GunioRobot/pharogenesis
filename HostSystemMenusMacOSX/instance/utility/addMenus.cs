addMenus
	
	| menu items |
	
	menu := self newMenu: 4 menuTitle: 'Tools'.
	items := self buildSubMenusFor: World worldMenu openMenu.
	items removeLast.
	items add: (HostSystemMenusMenuItem subMenu: 200 menuString: 'More...').
	self appendMenu: menu menuItems: items.
	self insertMenu: menu beforeID: 4.
	 
	items := self buildSubMenusFor: World worldMenu  registeredToolsMenu.
	menu := self newMenu: 200 menuTitle: 'registeredToolsMenu'.
	self insertMenu: menu beforeID: -1.
	self appendMenu: menu menuItems: items.
	
	menu := self newMenu: 5 menuTitle: 'Windows'.
	items := self buildSubMenusFor: World worldMenu  windowsMenu.
	self appendMenu: menu menuItems: items.
	self insertMenu: menu beforeID: 0.
	
	
	menu := self newMenu: 6 menuTitle: 'Debug'.
	items := self buildSubMenusFor: World worldMenu  debugMenu.
	self appendMenu: menu menuItems: items.
	self insertMenu: menu beforeID: 0.	

	
	self isHarvester ifTrue: [
		menu := self newMenu: 8 menuTitle: 'Harvesting'.
		items := OrderedCollection new. 
		items add: (HostSystemMenusMenuItem menuString: '1- Prepare new update' 
				handler: [:evt | ScriptLoader new prepareNewUpdate ]). 
		items add: (HostSystemMenusMenuItem menuString: '2- Done applying changes' 
				handler: [:evt | ScriptLoader new doneApplyingChanges ]). 
		items add: (HostSystemMenusMenuItem menuString: '3- Verify new update' 
				handler: [:evt | ScriptLoader new verifyNewUpdate]). 
		items add: (HostSystemMenusMenuItem menuString: '4- Publish changes'
				handler: [:evt | ScriptLoader new publishChanges ]). 
		self appendMenu: menu menuItems: items. 
		self insertMenu: menu beforeID: 0.	
		
	].

	