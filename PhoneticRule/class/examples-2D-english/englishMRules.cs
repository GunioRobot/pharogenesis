englishMRules
	^ #((''		'mov'	''		'm/uw/v')
		(''		'm'		''		'm')
	) collect: [ :each | self fromArray: each]