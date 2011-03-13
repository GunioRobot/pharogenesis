descriptionNamed: descriptionName at: index

	| array |
	(array _  self descriptionNamed: descriptionName) ifNil: [^ nil].
	^ array at: index.
