vertexAt: aPoint 
	| oldVertex |
	oldVertex _ self vertices at: aPoint asPoint ifAbsentPut: [POVertex at: aPoint].
	^ oldVertex