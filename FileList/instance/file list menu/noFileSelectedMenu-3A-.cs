noFileSelectedMenu: aMenu

	^ aMenu
		labels:
'sort by name
sort by size
sort by date
add new file'
		lines: # (3)
		selections: #(sortByName sortBySize sortByDate addNewFile)
