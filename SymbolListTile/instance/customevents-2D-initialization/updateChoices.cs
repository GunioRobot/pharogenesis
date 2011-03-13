updateChoices
	choices _ (Vocabulary vocabularyNamed: dataType) choices.
	(choices includes: literal) ifFalse: [ literal _ choices first. self changed ]