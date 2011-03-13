addModelItemsToWindowMenu: aMenu
	Smalltalk 
		at: #SystemBrowser 
		ifPresent: [:class | class 
								addRegistryMenuItemsTo: aMenu 
								inAccountOf: OBSystemBrowserAdaptor new].