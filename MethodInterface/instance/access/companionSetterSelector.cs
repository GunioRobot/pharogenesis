companionSetterSelector
	"If there is a companion setter selector, anwer it, else answer nil"

	^ resultSpecification ifNotNil:
		[resultSpecification companionSetterSelector]