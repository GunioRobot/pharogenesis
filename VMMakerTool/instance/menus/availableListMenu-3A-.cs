availableListMenu: aMenu

	aMenu addList:#(
			('make all external'						makeAllPluginsExternal)
			('make all internal'						makeAllPluginsInternal)
			('make all available'					makeAllPluginsAvailable)
			-
			('browse plugin' 						browseSelectedAvailablePlugin)).
	^ aMenu