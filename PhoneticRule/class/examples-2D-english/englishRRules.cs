englishRRules
	^ #((''		're'		'^#'		'r/iy')
		(''		'r'		''		'r')
	) collect: [ :each | self fromArray: each]