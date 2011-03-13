homepageString
	^package homepage
		ifNil: [ '' ]
		ifNotNil: [ package homepage toText ]