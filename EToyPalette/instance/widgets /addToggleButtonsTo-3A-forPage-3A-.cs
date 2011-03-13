addToggleButtonsTo: aLayoutPage forPage: aPageNumber
	| buttons spacer aRow aHolder aPresenter |
	aHolder _ self world standardHolder.
	aPresenter _ self world presenter.
	buttons _  aPageNumber == 1
		ifTrue:
			[aPresenter pageOneToggleButtonsFor: aHolder]
		ifFalse:
			[aPresenter pageTwoToggleButtonsFor: aHolder].

	aLayoutPage addMorphBack: (Morph new color: Color transparent; extent: 1 @ 12).
	spacer _ Morph new color: Color transparent; extent: 20@1.
	aRow _ AlignmentMorph newRow.
	aRow color: Color transparent; borderWidth: 0; inset: 0.
	aRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	aRow addMorphBack: spacer fullCopy; addMorphBack: buttons first; addMorphBack: spacer fullCopy; addMorphBack: buttons second.
	aLayoutPage addMorphBack: aRow.

	buttons size > 2 ifTrue:
		[aLayoutPage addMorphBack: (spacer fullCopy extent: 1@30).
		aRow _ AlignmentMorph newRow.
		aRow color: Color transparent; borderWidth: 0; inset: 0.
		aRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
		aRow addMorphBack: spacer fullCopy; addMorphBack: buttons third.
		buttons size > 3 ifTrue:
			[aRow addMorphBack: spacer fullCopy; addMorphBack: buttons fourth].
		aLayoutPage addMorphBack: aRow].