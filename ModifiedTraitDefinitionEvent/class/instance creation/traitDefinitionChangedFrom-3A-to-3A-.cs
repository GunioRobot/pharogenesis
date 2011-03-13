traitDefinitionChangedFrom: oldTrait to: newTrait
	| instance |
	instance _ self item: newTrait kind: self classKind.
	instance oldItem: oldTrait.
	^instance