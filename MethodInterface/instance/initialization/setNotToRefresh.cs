setNotToRefresh
	"Set the receiver up not to do periodic refresh."

	resultSpecification ifNotNil: [resultSpecification refetchFrequency: nil]