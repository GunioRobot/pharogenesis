privateMoveBy: delta
	super privateMoveBy: delta.
	vertices _ vertices collect: [:p | p + delta].
	self arrowForms do: [:f | f offset: f offset + delta]