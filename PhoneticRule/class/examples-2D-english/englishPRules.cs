englishPRules
	^ #((''		'ph'		''		'f')
		(''		'peop'	''		'p/iy/p')
		(''		'pow'	''		'p/aw')
		(''		'put'	' '		'p/uh/t')
		(''		'p'		''		'p')
	) collect: [ :each | self fromArray: each]