messageCategoryMenu: aMenu

^ aMenu labels:
'browse
printOut
fileOut
reorganize
add item...
rename...
remove'
	lines: #(3 4)
	selections:
		#(buildMessageCategoryBrowser printOutMessageCategories fileOutMessageCategories
		editMessageCategories
		addCategory renameCategory removeMessageCategory)
