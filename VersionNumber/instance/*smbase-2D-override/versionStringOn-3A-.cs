versionStringOn: strm

	| first |
	first := true.
	numbers do: [ :ea |
		first ifFalse: [strm nextPut: $.].
		first := false.
		ea printOn: strm]
	