classList
	"Answer an array of the class names of the selected category. Answer an 
	empty array if no selection exists."

	^systemCategoryListIndex = 0
		ifTrue: [
			self systemCategoryList isEmpty
				ifTrue: [systemOrganizer listAtCategoryNumber: (systemOrganizer categories indexOf: self package asSymbol)]
				ifFalse: [Array new]]
		ifFalse: [systemOrganizer listAtCategoryNumber:
			(systemOrganizer categories indexOf: self selectedSystemCategoryName asSymbol)]