listPane2NewSelection: t1 
	valuePrinter
		contents: (t1 = 0
				ifTrue: ['-']
				ifFalse: [(listPane2 instVarNamed: 'list')
						at: t1]).
	listPane2 selectionIndex: t1.
	listPane1 selectionIndex: t1