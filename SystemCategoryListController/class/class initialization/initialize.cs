initialize
	"SystemCategoryListController initialize"
	SystemCategoryListYellowButtonMenu _ 
		PopUpMenu 
			labels:
'find class...
recent classes...
browse all
browse
printOut
fileOut
reorganize
update
add item...
rename...
remove' 
			lines: #(2 4 6 8).
	SystemCategoryListYellowButtonMessages _
		#(findClass findRecentClass browseAllClasses browse
		printOut fileOut
		edit update
		add rename remove )
	"
	SystemCategoryListController initialize.
	SystemCategoryListController allInstancesDo:
		[:x | x initializeYellowButtonMenu]
	"