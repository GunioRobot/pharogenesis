englishWRules
	^ #((' '		'were'	''		'w/er')
		(''		'wa'	's'		'w/aa')
		(''		'wa'	't'		'w/aa')
		(''		'where'	''		'wh/eh/r')
		(''		'what'	''		'wh/aa/t')
		(''		'whol'	''		'hh/ow/l')
		(''		'who'	''		'hh/uw')
		(''		'wh'	''		'wh')
		(''		'war'	''		'w/ao/r')
		(''		'wor'	'^'		'w/er')
		(''		'wr'	''		'r')
		(''		'w'		''		'w')
	) collect: [ :each | self fromArray: each]