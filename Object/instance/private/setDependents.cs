setDependents
	"Allocate the soft field for the receiver's dependents."

	DependentsFields add: (Association key: self value: OrderedCollection new)