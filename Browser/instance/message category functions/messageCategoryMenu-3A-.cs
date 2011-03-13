messageCategoryMenu: aMenu
	ServiceGui browser: self messageCategoryMenu: aMenu.
	ServiceGui onlyServices ifTrue: [^aMenu].
	^ aMenu labels:
'browse
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
		#(buildMessageCategoryBrowser fileOutMessageCategories
		editMessageCategories alphabetizeMessageCategories removeEmptyCategories
		categorizeAllUncategorizedMethods addCategory renameCategory removeMessageCategory)
