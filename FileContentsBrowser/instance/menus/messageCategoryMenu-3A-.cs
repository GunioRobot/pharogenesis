messageCategoryMenu: aMenu

	^ aMenu 
		labels:
'fileIn
fileOut
reorganize
add item...
rename...
remove
remove existing'
		lines: #(2 3 6)
		selections: #(fileInMessageCategories fileOutMessageCategories editMessageCategories addCategory renameCategory removeMessageCategory removeUnmodifiedMethods)