englishGRules
	^ #((''		'giv'	''		'g/iy/v')
		(' '		'g'		'i^'		'g')
		(''		'ge'		't'		'g/eh')
		('su'	'gges'	''		'g/jh/eh/s')
		(''		'gg'		''		'g')
		(' b#'	'g'		''		'g')
		(''		'g'		'+'		'jh')
		(''		'great'	''		'g/r/ey/t')
		('#'		'gh'		''		'')
		(''		'g'		''		'g')
	) collect: [ :each | self fromArray: each]