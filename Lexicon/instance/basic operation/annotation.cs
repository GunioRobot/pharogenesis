annotation
	"Provide a line of annotation material for a middle pane."

	| aCategoryName |
	self selectedMessageName ifNotNil: [^ super annotation].
	(aCategoryName _ self selectedCategoryName) ifNil:
		[^ self hasSearchPane
			ifTrue:
				['type a message name or fragment in the top pane and hit RETURN or ENTER']
			ifFalse:
				[''  "currentVocabulary documentation"]].


	(aCategoryName = self class queryCategoryName) ifTrue:
		[^ self queryCharacterization].
		
	#(
	(allCategoryName			'Shows all methods, whatever other category they belong to')
	(viewedCategoryName		'Methods visited recently.  Use  "-" button to remove a method from this category.')
	(queryCategoryName		'Query results'))

		do:
			[:pair | (self categoryWithNameSpecifiedBy: pair first) = aCategoryName ifTrue: [^ pair second]].

	^ currentVocabulary categoryCommentFor: aCategoryName