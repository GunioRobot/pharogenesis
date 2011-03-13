categoryCommentFor: aCategoryName
	"Answer diocumentation for the given category name, a symbol"

	categories do:
		[:cat | cat categoryName == aCategoryName ifTrue: [^ cat documentation]].

	aCategoryName = self allCategoryName ifTrue:
		[^ 'Shows all methods, whatever other categories they may belong to'].
	#(
	(all					'Danger! An old designation that usually does NOT include all of anything!')
	('as yet unclassified'	'Methods not yet given a specific classification in some class in which they are implemented')
	(private				'Methods that should only be called by self'))

		do:
			[:pair | pair first = aCategoryName ifTrue: [^ pair second]].

	^ aCategoryName, ' is a category that currently has no documentation'
