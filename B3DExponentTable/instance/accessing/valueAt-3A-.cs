valueAt: aFloat
	"Return the table approximation for the given float value"
	| index max |
	aFloat < 0.0 ifTrue:[^self error:'Cannot use negative numbers in table lookup'].
	max _ self size // 2.
	index _ (max * aFloat) asInteger + 1.
	index >= max ifTrue:[^self at: self size-1].
	"Linear interpolation inbetween"
	^(self at: index) + (aFloat - (index-1) * (self at: index+1))