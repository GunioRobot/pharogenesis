selected: aColumn 
	aColumn next ifNotNilDo: 
		[:next | 
		next parent: aColumn selectedNode].