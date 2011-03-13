tearDown
	| dir |
	dir := FileDirectory default.
	self createdClassesAndTraits, self resourceClassesAndTraits  do: [:each |
		dir deleteFileNamed: each asString , '.st' ifAbsent: []].
	dir deleteFileNamed: self categoryName , '.st' ifAbsent: [].
	SystemOrganization removeSystemCategory: self categoryName.
	super tearDown