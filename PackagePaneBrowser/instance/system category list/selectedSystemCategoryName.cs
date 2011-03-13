selectedSystemCategoryName
	"Answer the name of the selected system category or nil."

	systemCategoryListIndex = 0
		ifTrue: [^nil].
	packageListIndex = 0
		ifTrue: [^ self systemCategoryList at: systemCategoryListIndex].
	^ self package , '-' , (self systemCategoryList at: systemCategoryListIndex)