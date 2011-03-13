initialize
	"SystemCategoryListController initialize"
	SystemCategoryListYellowButtonMenu _ 
		PopUpMenu 
			labels:
'find class...
browse
printOut
fileOut
reorganize
update
add item...
rename...
remove' 
			lines: #(1 3 6).
	SystemCategoryListYellowButtonMessages _
		#(findClass browse printOut fileOut
		edit update
		add rename remove )
	"
	SystemCategoryListController initialize.
	SystemCategoryListController allInstancesDo:
		[:x | x initializeYellowButtonMenu]
	"