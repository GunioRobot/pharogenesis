rebuildApplicationMenuHandlers: aMenuRef
	| maximumItems applicationMenuItemsTitles applicationMenuItems m applicationQuit |

	maximumItems := self countMenuItems: aMenuRef.
	applicationMenuItemsTitles := (1 to: maximumItems) collect: [:i | self getMenuItemText: aMenuRef item: i]. 	
	applicationMenuItems := applicationMenuItemsTitles collect: [:e | HostSystemMenusMenuItem menuString: e].
	applicationQuit := applicationMenuItems detect: [:e | e text = 'Quit Pharo '] ifNone: [applicationQuit := applicationMenuItems detect: [:e | e text = 'Quit Squeak VM '] ifNone: [nil].].
	applicationQuit ifNotNil: [applicationQuit handler: 
		[:evt | SmalltalkImage current snapshot:
			(self confirm: 'Save changes before quitting?'
				orCancel: [^ self])
				andQuit: true]]. 
	m := Dictionary new.
	applicationMenuItems doWithIndex:[:e :i | m at: i put: e].
	self menus at: (self getMenuID: aMenuRef) put: m.

