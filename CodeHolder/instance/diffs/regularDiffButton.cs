regularDiffButton
	"Return a checkbox that lets the user decide whether regular diffs should be shown or not"

	|  outerButton aButton |
	outerButton := AlignmentMorph newRow.
	outerButton wrapCentering: #center; cellPositioning: #leftCenter.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton := UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleRegularDiffing;
		getSelector: #showingRegularDiffs.
	outerButton addMorphBack: (StringMorph contents: 'diffs') lock.
	outerButton setBalloonText: 'If checked, then code differences from the previous version, if any, will be shown.'.

	^ outerButton
