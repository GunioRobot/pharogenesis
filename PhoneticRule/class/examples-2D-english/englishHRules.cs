englishHRules
	^ #((' '		'hav'	''		'hh/ae/v')
		(' '		'here'	''		'hh/iy/r')
		(' '		'hour'	''		'aw/er')
		(''		'how'	''		'hh/aw')
		(''		'h'		'#'		'hh')
		(''		'h'		''		'')
	) collect: [ :each | self fromArray: each]