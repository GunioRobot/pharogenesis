rigAFewCategories
	"Formerly used to rig generic categories, now seemingly disfunctional and in abeyance"

	| aMethodCategory |
	true ifTrue: [^ self].

	self flag: #deferred.
"Vocabulary fullVocabulary rigAFewCategories "
	#(	(accessing	'Generally holds methods to read and write instance variables')
		(initialization	'messages typically sent when an object is created, to set up its initial state'))

		do:
			[:pair |
				aMethodCategory _ ElementCategory new categoryName: pair first.
				aMethodCategory documentation: pair second.
				self addCategory: aMethodCategory]