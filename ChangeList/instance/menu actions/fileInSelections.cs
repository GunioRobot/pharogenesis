fileInSelections 
	| any |
	any _ false.
	listSelections with: changeList do: 
		[:selected :item | selected ifTrue: [any _ true. item fileIn]].
	any ifFalse:
		[self inform: 'nothing selected, so nothing done']