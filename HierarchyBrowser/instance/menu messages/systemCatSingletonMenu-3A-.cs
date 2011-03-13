systemCatSingletonMenu: aMenu

	^ aMenu labels:
'find class... (f)
browse
fileOut
update
rename...
remove' 
	lines: #(1 4)
	selections:
		#(findClass buildSystemCategoryBrowser
		 fileOutSystemCategory updateSystemCategories
		 renameSystemCategory removeSystemCategory )
