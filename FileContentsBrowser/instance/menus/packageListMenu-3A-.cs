packageListMenu: aMenu
	^ aMenu 
		labels:
'find class... (f)
fileIn
file into new changeset
fileOut
remove
remove existing'
		lines: #(1 4 5)
		selections: #(findClass fileInPackage fileIntoNewChangeSet fileOutPackage removePackage removeUnmodifiedClasses)