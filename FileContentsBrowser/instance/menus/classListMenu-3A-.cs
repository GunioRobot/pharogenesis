classListMenu: aMenu

	^ aMenu 
		labels:
'definition
comment
browse full (b)
class refs (N)
fileIn
fileOut
rename...
remove
remove existing'
		lines: #(2 4 6 8)
		selections: #(editClass editComment browseMethodFull browseClassRefs fileInClass fileOutClass renameClass removeClass removeUnmodifiedCategories) 

