englishPunctuationRules
	^ #(('.'		'''s'		''		'z')
		('#:.e'	'''s'		''		'z')
		('#'		'''s'		''		'z')
	) collect: [ :each | self fromArray: each]