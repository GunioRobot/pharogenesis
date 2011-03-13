placeArgumentIn 
	"Let the user choose a new layer in the core sample for the argument to reside in, but don't allow strange loops"
	|  targetMorph |
	targetMorph _ self selectTargetMorph: ('Place ', argument externalName, ' in...') excluding: argument.
	targetMorph ifNotNil:
		[targetMorph addMorphFront: argument fromWorldPosition: argument position]
