magdeburg
	"Alternative window & scroll-bar looks, no desktop command keys, no keyboard menu control, no annotation panes..."

	self setPreferencesFrom: #(
		(alternativeScrollbarLook true)
		(alternativeWindowLook true)
		(annotationPanes false)
		(browseWithDragNDrop true)
		(canRecordWhilePlaying false)
		(classicNavigatorEnabled true)
		(conversionMethodsAtFileOut true)
		(dragNDropWithAnimation true)
		(haloTransitions true)
		(honorDesktopCmdKeys false)
		(magicHalos true)
		(menuKeyboardControl false)  
		(scrollBarsWithoutMenuButton true)).

	self installBrightWindowColors