internalListMenu: aMenu

	aMenu addList:#(
			('make all external'						makeAllPluginsExternal)
			('make all internal'						makeAllPluginsInternal)
			('make all available'					makeAllPluginsAvailable)
			-
			('browse plugin' 						browseSelectedInternalPlugin)
			-
			('generate plugin'						generateSelectedInternalPlugin)).
	^ aMenu