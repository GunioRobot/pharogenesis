externalListMenu: aMenu

	aMenu addList:#(
			('make all external'						makeAllPluginsExternal)
			('make all internal'						makeAllPluginsInternal)
			('make all available'					makeAllPluginsAvailable)
			-
			('browse plugin' 						browseSelectedExternalPlugin)
			-
			('generate plugin'						generateSelectedExternalPlugin)).
	^ aMenu