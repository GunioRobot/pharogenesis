standaloneResumeButton

	| r |

	r _ AlignmentMorph newRow.
	r color: Color red; borderWidth: 0; layoutInset: 6; useRoundedCorners.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (
		SimpleButtonMorph new
			target: [
				scorePlayer resumePlaying.
				r delete
			];
			borderColor: #raised;
			borderWidth: 2;
			color: Color green;
			label: 'Continue';
			actionSelector: #value
	).
	r setBalloonText: 'Continue playing a paused presentation'.
	^r


