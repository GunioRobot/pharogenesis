englishCRules
	^ #((' '		'ch'		'^'		'k')
		('^e'	'ch'		''		'k')
		(''		'ch'		''		'ch')
		(' s'		'ci'		'#'		's/ay')
		(''		'ci'		'a'		'sh')
		(''		'ci'		'o'		'sh')
		(''		'ci'		'en'		'sh')
		(''		'c'		'+'		's')
		(''		'ck'		''		'k')
		(''		'com'	'%'		'k/ah/m')
		(''		'c'		''		'k')
	) collect: [ :each | self fromArray: each]