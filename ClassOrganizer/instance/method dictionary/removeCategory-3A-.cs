removeCategory: cat 
	"Remove the category named, cat. Create an error notificiation if the 
	category has any elements in it."

	| index lastStop |
	index _ categoryArray indexOf: cat ifAbsent: [^self].
	lastStop _ 
		index = 1
			ifTrue: [0]
			ifFalse: [categoryStops at: index - 1].
	(categoryStops at: index) - lastStop > 0 
		ifTrue: [^self error: 'cannot remove non-empty category'].
	categoryArray _ categoryArray copyReplaceFrom: index to: index with: Array new.
	categoryStops _ categoryStops copyReplaceFrom: index to: index with: Array new.
	categoryArray size = 0
		ifTrue:
			[categoryArray _ Array with: Default.
			categoryStops _ Array with: 0]
