initialize

	MessageCategoryListYellowButtonMenu _ 
		PopUpMenu labels:
'browse
printOut
fileOut
reorganize
add item...
rename...
remove'
		lines: #(3 4).
	MessageCategoryListYellowButtonMessages _
		#(browse printOut fileOut
		reorganize
		add rename remove )
	"
	MessageCategoryListController initialize.
	MessageCategoryListController allInstancesDo:
		[:x | x initializeYellowButtonMenu].
	"