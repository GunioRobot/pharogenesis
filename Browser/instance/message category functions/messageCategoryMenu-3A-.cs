messageCategoryMenu: aMenu

^ aMenu labels:
'browse
printOut
fileOut
reorganize
alphabetize
remove empty categories
new category...
rename...
remove'
	lines: #(3 7)
	selections:
		#(buildMessageCategoryBrowser printOutMessageCategories fileOutMessageCategories
		editMessageCategories alphabetizeMessageCategories removeEmptyCategories
		addCategory renameCategory removeMessageCategory)
