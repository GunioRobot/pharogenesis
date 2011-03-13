pseudoCopy
	"This method is never run. It is here just so that the sends in it can be
	tallied by the SendInfo interpreter."
	| array |
	array := self class new: self basicSize.
	self
		instVarsWithIndexDo: [:each :i | array at: i put: each].
	^ array