bounds
	| origin corner |
	origin _ self vertices first.
	corner _ self vertices last.
	self vertices do: 
		[:vertex | 
		origin _ origin min: vertex.
		corner _ corner max: vertex].
	^ origin corner: corner