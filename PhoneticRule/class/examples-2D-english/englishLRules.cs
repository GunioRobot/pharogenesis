englishLRules
	^ #((''		'lo'		'c#'		'l/ow')
		('l'		'l'		''		'')
		('#:^'	'l'		'%'		'ax/l')
		(''		'lead'	''		'l/iy/d')
		(''		'l'		''		'l')
	) collect: [ :each | self fromArray: each]