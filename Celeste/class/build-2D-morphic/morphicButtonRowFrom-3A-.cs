morphicButtonRowFrom: buttons 
	| aRow |
	aRow _ AlignmentMorph newRow.
	aRow setNameTo: 'buttonPane'.
	aRow beSticky.
	aRow hResizing: #spaceFill.
	aRow wrapCentering: #center;
		 cellPositioning: #leftCenter.
	aRow clipSubmorphs: true.
	aRow addTransparentSpacerOfSize: 5 @ 0.
	buttons
		do: [:btn | 
			btn useRoundedCorners;
			 hResizing: #spaceFill;
						 vResizing: #spaceFill.
			aRow addMorphBack: btn.
			aRow addTransparentSpacerOfSize: 3 @ 0].
	^ aRow