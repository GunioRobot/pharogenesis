setToRefetch
	"Set the receiver up to expect a refetch, assuming it has a result specification"

	resultSpecification ifNotNil: [resultSpecification refetchFrequency: 1]