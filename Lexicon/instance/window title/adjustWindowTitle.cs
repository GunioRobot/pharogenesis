adjustWindowTitle
	"Set the title of the receiver's window, if any, to reflect the current choices"

	| aWindow aLabel catName |
	(catName := self selectedCategoryName) ifNil: [^ self].
	(aWindow := self containingWindow) ifNil: [^ self].
	aLabel := nil.
	#(	(viewedCategoryName		'Messages already viewed - ')
		(allCategoryName			'All messages - ')) do:
			[:aPair | catName = (self categoryWithNameSpecifiedBy: aPair first) ifTrue: [aLabel := aPair second]].

	aLabel ifNil:
		[aLabel := catName = self class queryCategoryName
			ifTrue:
				[self queryCharacterization, ' - ']
			ifFalse:
				['Vocabulary of ']].
	aWindow setLabel: aLabel, (self targetObject ifNil: [targetClass]) nameForViewer