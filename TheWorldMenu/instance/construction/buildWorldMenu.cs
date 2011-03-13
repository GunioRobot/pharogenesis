buildWorldMenu
	"Build the menu that is put up when the screen-desktop is clicked on"
	| menu |
	menu := MenuMorph new defaultTarget: self.
	menu commandKeyHandler: self.
	menu addStayUpItem.
	
	menu
		defaultTarget: ToolSet default;
		addList: ToolSet default mainMenuItems.
	menu defaultTarget: self.
	
	self fillIn: menu from: {nil}.
	
	menu add: 'Tools' subMenu: self openMenu.
	menu add: 'Windows' subMenu: self windowsMenu.
	menu add: 'Debug' subMenu: self debugMenu.
	menu add: 'System' subMenu: self systemMenu.
	
	self fillIn: menu from: {nil}.

	self fillIn: menu from: {
		nil.
		{'Save'. {SmalltalkImage current. #saveSession}. 'save the current version of the image on disk'}.
		{'Save As...'. {self. #saveAs}. 'save the current version of the image on disk under a new name.'}.
		{'Save and quit'. {self. #saveAndQuit}. 'save the current image on disk, and quit out of Pharo.'}.
	 	{'Quit'. {self. #quitSession}. 'quit out of Pharo.'}
	}.
	^ menu