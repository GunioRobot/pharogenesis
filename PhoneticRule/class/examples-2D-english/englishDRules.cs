englishDRules
	^ #(('#:'	'ded'	' '		'd/ih/d')
		('.e'		'd'		' '		'd')
		('#:^e'	'd'		' '		't')
		(' '		'de'		'^#'		'd/ih')
		(' '		'do'		' '		'd/uw')
		(' '		'does'	''		'd/ah/z')
		(' '		'doing'	''		'd/uw/ih/ng')
		(' '		'dow'	''		'd/aw')
		(''		'du'		'a'		'jh/uw')
		(''		'd'		''		'd')
	) collect: [ :each | self fromArray: each]