resultType
	"Answer the result type"

	^ resultSpecification
		ifNotNil:
			[resultSpecification type]
		ifNil:
			[#unknown]