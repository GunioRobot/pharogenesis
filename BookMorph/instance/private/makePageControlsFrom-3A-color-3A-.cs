makePageControlsFrom: controlSpecs color: aColor

	| aButton aColumn aRow but |
	aButton _ SimpleButtonMorph new target: self; borderColor: Color black; color: aColor.
	aColumn _ AlignmentMorph newColumn.
	aColumn color: aButton color; borderWidth: 0; inset: 0.
	aColumn hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.

	aRow _ AlignmentMorph newRow.
	aRow color: aButton color; borderWidth: 0; inset: 0.
	aRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	controlSpecs do:
		[:pair | aRow addMorphBack: (but _ aButton fullCopy label: pair first; actionSelector: pair second).
		but setBalloonText: pair third.
		(pair last includesSubString: 'enu')
			ifTrue: [but actWhen: #buttonDown]].
	aColumn addMorphBack: aRow.

	aColumn setNameTo: 'Page Controls'.
	
	^ aColumn