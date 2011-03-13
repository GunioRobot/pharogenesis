messageCategoryMenu: aMenu
	ServiceGui browser: self messageCategoryMenu: aMenu.
	ServiceGui onlyServices ifTrue: [^aMenu].
	^ aMenu labels:
'browse
printOut
fileOut
reorganize
alphabetize
remove empty categories
categorize all uncategorized
new category...
rename...
remove'
		lines: #(3 8)
		selections:
		#(buildMessageCategoryBrowser printOutMessageCategories fileOutMessageCategories
		editMessageCategories alphabetizeMessageCategories removeEmptyCategories
		categorizeAllUncategorizedMethods addCategory renameCategory removeMessageCategory)
