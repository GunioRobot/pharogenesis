asEdgeList
	| edgeList |
	edgeList _ POEdgeList new.
	self vertices do: [:vertex | edgeList edgeFrom: vertex to: (self after: vertex)]