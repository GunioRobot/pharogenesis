fraction: newFraction
	"Do my interpolation based on the new values"
	| keys values index delta newValue |
	fraction = newFraction ifTrue:[^self].
	keys _ self key.
	values _ self keyValue.
	newFraction <= keys first ifTrue:[^self value: values first].
	newFraction >= keys last ifTrue:[^self value: values first].
	index _ self largerIndexOf: newFraction in: keys.
	delta _ newFraction - (keys at: index-1).
	newValue _ (values at: index-1) interpolateTo: (values at: index) at: delta.
	fraction _ newFraction.
	self value: newValue.