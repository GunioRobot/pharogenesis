systemCatSingletonMenu: aMenu

	^ aMenu labels:
'find class... (f)
browse
printOut
fileOut
update
rename...
remove' 
	lines: #(1 4)
	selections:
		#(findClass buildSystemCategoryBrowser
		printOutSystemCategory fileOutSystemCategory updateSystemCategories
		 renameSystemCategory removeSystemCategory )
