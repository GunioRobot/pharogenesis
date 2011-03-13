makeMinimalControlsWithColor: aColor title: aString

	| aButton aColumn aRow but |
	aButton _ SimpleButtonMorph new target: self; borderColor: Color black; color: aColor; borderWidth: 0.
	aColumn _ AlignmentMorph newColumn.
	aColumn color: aButton color; borderWidth: 0; inset: 0.
	aColumn hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.

	aRow _ AlignmentMorph newRow.
	aRow color: aButton color; borderWidth: 0; inset: 0.
	aRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.

	aRow addMorphBack: (but _ aButton fullCopy label: ' < ' ; actionSelector: #previousPage).
	but setBalloonText: 'Go to previous page'.

	aRow addMorphBack: (StringMorph contents: aString) lock.

	aRow addMorphBack: (but _ aButton fullCopy label: ' > ' ; actionSelector: #nextPage).
	but setBalloonText: 'Go to next page'.

	aColumn addMorphBack: aRow.

	aColumn setNameTo: 'Page Controls'.
	
	^ aColumn