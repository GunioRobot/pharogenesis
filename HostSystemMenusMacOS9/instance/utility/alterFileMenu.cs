alterFileMenu 
	| fileMenu items |	

	fileMenu := self getMenuHandle: 2.
	items := OrderedCollection 
			with: (HostSystemMenusMenuItem menuString: 'Quit do not save')
			with: (HostSystemMenusMenuItem menuString: '-')
			with: (HostSystemMenusMenuItem menuString: 'Save' 
				handler: [:evt | Smalltalk snapshot: true andQuit: false ] )
			with: (HostSystemMenusMenuItem menuString: 'Save As...' 
				handler: [:evt | SmalltalkImage current saveAs])
			with: (HostSystemMenusMenuItem menuString: '-')
			with: (HostSystemMenusMenuItem menuString: 'Quit VM '
				handler: [:evt | SmalltalkImage current snapshot:
			(self confirm: 'Save changes before quitting?'
				orCancel: [^ self])
				andQuit: true]).
	(self countMenuItems: fileMenu) > 1 
		ifTrue: 
			[1 to: items size do: 
				[:i | self setHandlerForMenu: 2 item: i  handler: (items at: i)]]
		ifFalse:
			[self deleteMenuItem: fileMenu item: 1.
			self appendMenu: fileMenu menuItems: items].
	
	
	
	