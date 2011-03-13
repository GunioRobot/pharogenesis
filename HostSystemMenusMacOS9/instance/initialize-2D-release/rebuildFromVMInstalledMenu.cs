rebuildFromVMInstalledMenu
	| editMenu fileMenuID editMenuID fileMenu |

	fileMenuID := 2.
	editMenuID := 3.
	editMenu := OrderedCollection 
		with: (HostSystemMenusMenuItem menuString: 'Undo' keyboardKey: $z)
		with: (HostSystemMenusMenuItem menuString: '_')
		with: (HostSystemMenusMenuItem menuString: 'Cut' keyboardKey: $x)
		with: (HostSystemMenusMenuItem menuString: 'Copy' keyboardKey: $c)
		with: (HostSystemMenusMenuItem menuString: 'Paste' keyboardKey: $v)
		with: (HostSystemMenusMenuItem menuString: 'Clear').
	fileMenu := OrderedCollection 
		with: (HostSystemMenusMenuItem menuString: 'Quit do not save').
	1 to: fileMenu size do: 
		[:i | self setHandlerForMenu: fileMenuID item: i  handler: (fileMenu at: i)].
	1 to: editMenu size do: 
		[:i | self setHandlerForMenu: editMenuID item: i  handler: (editMenu at: i)].

	
	