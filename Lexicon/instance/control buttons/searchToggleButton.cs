searchToggleButton
	"Return a checkbox governing whether a search pane or a categories pane is used.  No senders at the moment, but this feature might be useful someday."

	|  outerButton aButton |
	outerButton _ AlignmentMorph newRow.
	outerButton wrapCentering: #center; cellPositioning: #leftCenter.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleSearch;
		getSelector: #hasSearchPane.
	outerButton addMorphBack: (StringMorph contents: 'search') lock.
	outerButton setBalloonText: 'If checked, then a search pane is used, if not, then a categories pane will be seen instead'.

	^ outerButton
