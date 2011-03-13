diffButton
	"Return a checkbox that lets the user decide whether diffs should be shown or not.  Not sent any more but retained against the possibility of existing subclasses outside the base image using it."

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
