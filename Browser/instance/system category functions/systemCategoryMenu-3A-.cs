systemCategoryMenu: aMenu
		
	ServiceGui browser: self classCategoryMenu: aMenu.
	ServiceGui onlyServices ifTrue: [^aMenu].
	^ aMenu labels:
'find class... (f)
recent classes... (r)
browse
fileOut
reorganize
alphabetize
update
add category...
rename...
remove' 
	lines: #(2 4 6 8)
	selections:
		#(findClass recent buildSystemCategoryBrowser
		fileOutSystemCategory
		editSystemCategories alphabetizeSystemCategories updateSystemCategories
		addSystemCategory renameSystemCategory removeSystemCategory )