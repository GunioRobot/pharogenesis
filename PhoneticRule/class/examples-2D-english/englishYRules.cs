englishYRules
	^ #((''		'young'	''		'y/ah/ng')
		(' '		'you'	''		'y/uw')
		(' '		'yes'	''		'y/eh/s')
		(' '		'y'		''		'y')
		('#:^'	'y'		' '		'iy')
		('#:^'	'y'		'i'		'iy')
		(' :'		'y'		''		'ay')
		(' :'		'y'		'#'		'ay')
		(' :'		'y'		'^+:#'	'ih')
		(' :'		'y'		'^#'		'ay')
		(''		'y'		''		'ih')
	) collect: [ :each | self fromArray: each]