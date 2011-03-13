parentNodeForColumn: aColumn
	^ [(columns before: aColumn) selectedNode]
		on: Error
		do: [:err | ^ root]