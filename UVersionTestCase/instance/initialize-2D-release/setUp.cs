setUp
	typicalVersions := #(
		'1'
		'2'
		'1.5.7'
		'1.5.8'
		'1.6.2'
		'1.5'
		'1.5a'
		'1.5b'
		'1.6'
		'alpha'
		'beta'
	) collect: [ :str | UVersion readFromString: str ].
	