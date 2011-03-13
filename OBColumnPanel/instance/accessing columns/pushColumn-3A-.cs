pushColumn: aColumn 
	self columns addLast: aColumn.
	self changed: #panes.
