wantsReadoutInViewer
	"Answer whether the method represented by the receiver is one which should have a readout in a viewer"

	^ resultSpecification notNil and:
		[resultSpecification refetchFrequency notNil]