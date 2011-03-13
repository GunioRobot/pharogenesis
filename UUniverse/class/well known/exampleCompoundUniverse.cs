exampleCompoundUniverse
	"[UUniverse switchSystemToUniverse: UUniverse exampleCompoundUniverse]"
	^(UCompoundUniverse composedOf: {
		self developmentUniverse.
		self homeMoviesUniverse
	}) description: 'example compound universe'; yourself