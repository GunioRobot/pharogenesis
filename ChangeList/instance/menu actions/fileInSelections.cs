fileInSelections 
	listSelections with: changeList do: 
		[:selected :item | selected ifTrue: [item fileIn]]