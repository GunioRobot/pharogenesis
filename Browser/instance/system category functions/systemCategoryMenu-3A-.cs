systemCategoryMenu: aMenu
		
	ServiceGui browser: self classCategoryMenu: aMenu.
	ServiceGui onlyServices ifTrue: [^aMenu].
	^ aMenu labels:
'find class... (f)
recent classes... (r)
browse all
browse
printOut
fileOut
reorganize
alphabetize
update
add item...
rename...
remove' 
	lines: #(2 4 6 8)
	selections:
		#(findClass recent browseAllClasses buildSystemCategoryBrowser
		printOutSystemCategory fileOutSystemCategory
		editSystemCategories alphabetizeSystemCategories updateSystemCategories
		addSystemCategory renameSystemCategory removeSystemCategory )