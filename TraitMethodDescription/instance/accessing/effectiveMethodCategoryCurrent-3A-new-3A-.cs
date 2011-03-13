effectiveMethodCategoryCurrent: currentCategoryOrNil new: newCategoryOrNil
	| isCurrent result cat size isConflict |
	size _ self size.
	size = 0 ifTrue: [^ nil].
	result _ self locatedMethods anyOne category.
	size = 1 ifTrue: [^ result].
	
	isCurrent _ currentCategoryOrNil isNil.
	isConflict _ false.
	self locatedMethods do: [:each |
		cat _ each category.
		isCurrent _ isCurrent or: [cat == currentCategoryOrNil].
		isConflict _ isConflict or: [cat ~~ result]].
	isConflict ifFalse: [^ result].
	(isCurrent not and: [newCategoryOrNil notNil]) ifTrue: [^ newCategoryOrNil].
	^ ClassOrganizer ambiguous.