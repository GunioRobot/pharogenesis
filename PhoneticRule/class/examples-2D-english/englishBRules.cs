englishBRules
	^ #((' '		'be'		'^#'		'b/ih')
		(''		'being'	''		'b/iy/ih/ng')
		(' '		'both'	''		'b/ow/th')
		(' '		'bus'	'#'		'b/ih/z')
		(''		'buil'	''		'b/ih/l')
		(''		'b'		''		'b')
	) collect: [ :each | self fromArray: each]