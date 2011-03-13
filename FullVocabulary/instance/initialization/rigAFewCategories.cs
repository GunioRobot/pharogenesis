rigAFewCategories
	"Rig a few catgories, mate.   'Vocabulary fullVocabulary rigAFewCategories'"

	| aMethodCategory |
	#(	(accessing	'Generally holds methods to read and write instance variables')
		(initialization	'messages typically sent when an object is created, to set up its initial state'))

		do:
			[:pair |
				aMethodCategory _ ElementCategory new categoryName: pair first.
				aMethodCategory documentation: pair second.
				self addCategory: aMethodCategory]