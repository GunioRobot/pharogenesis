removeTriangle: triangle 
	self faces removeKey: triangle ifAbsent: [^ self].
	triangle vertices do: [:vertex | vertex faces remove: triangle]