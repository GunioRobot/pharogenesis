privateMoveBy: delta
	super privateMoveBy: delta.
	vertices _ vertices collect: [:p | p + delta].
	self arrowForms do: [:f | f offset: f offset + delta].
	curveState _ nil.  "Force recomputation"
	(self valueOfProperty: #referencePosition) ifNotNilDo:
		[:oldPos | self setProperty: #referencePosition toValue: oldPos + delta]