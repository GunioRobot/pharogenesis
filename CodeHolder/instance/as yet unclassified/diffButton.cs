diffButton
	|  outerButton aButton |
	"Return a checkbox that lets the user decide whether diffs should be shown or not"
	outerButton _ AlignmentMorph newRow.
	outerButton centering: #center.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleDiff;
		getSelector: #showDiffs.
	outerButton addMorphBack: (StringMorph contents: 'diffs') lock.
	outerButton setBalloonText: 'If checked, then code differences from the previous version, if any, will be shown.'.

	^ outerButton
