englishNRules
	^ #(('e'		'ng'		'+'		'n/jh')
		(''		'ng'		'r'		'ng/g')
		(''		'ng'		'#'		'ng/g')
		(''		'ngl'	'%'		'ng/g/ax/l')
		(''		'ng'		''		'ng')
		(''		'nk'		''		'ng/k')
		(' '		'now'	' '		'n/aw')
		(''		'n'		''		'n')
	) collect: [ :each | self fromArray: each]