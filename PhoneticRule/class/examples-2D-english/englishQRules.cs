englishQRules
	^ #((''		'quar'	''		'k/w/ao/r')
		(''		'qu'		''		'k/w')
		(''		'q'		''		'k')
	) collect: [ :each | self fromArray: each]