sourceOrInfoButton
	"Return a checkbox that lets the user decide whether the full source or just documentation should show in the code pane"

	|  outerButton aButton |
	outerButton _ AlignmentMorph newRow.
	outerButton wrapCentering: #center; cellPositioning: #leftCenter.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleShowDocumentation;
		getSelector: #showingSource.
	outerButton addMorphBack: (StringMorph contents: 'source') lock.
	outerButton setBalloonText: 'If checked, then source code is shown in the text pane, if not, then documentation is shown'.

	^ outerButton
