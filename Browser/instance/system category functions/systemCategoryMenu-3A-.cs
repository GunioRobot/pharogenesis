systemCategoryMenu: aMenu

^ aMenu labels:
'find class...
recent classes...
browse all
browse
printOut
fileOut
reorganize
update
add item...
rename...
remove' 
	lines: #(2 4 6 8)
	selections:
		#(findClass recent browseAllClasses buildSystemCategoryBrowser
		printOutSystemCategory fileOutSystemCategory
		editSystemCategories updateSystemCategories
		addSystemCategory renameSystemCategory removeSystemCategory )
