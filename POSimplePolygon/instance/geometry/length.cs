length
	| length |
	length _ 0.
	self vertices do: [:vertex | length _ length + (vertex dist: (self after: vertex))].
	^ length