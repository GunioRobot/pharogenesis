prettyDiffButton
	"Return a checkbox that lets the user decide whether prettyDiffs should be shown or not"

	|  outerButton aButton |
	outerButton := AlignmentMorph newRow.
	outerButton wrapCentering: #center; cellPositioning: #leftCenter.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton := UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #togglePrettyDiffing;
		getSelector: #showingPrettyDiffs.
	outerButton addMorphBack: (StringMorph contents: 'prettyDiffs') lock.
	(self isKindOf: VersionsBrowser)
		ifTrue:
			[outerButton setBalloonText: 'If checked, then pretty-printed code differences from the previous version, if any, will be shown.']
		ifFalse:
			[outerButton setBalloonText: 'If checked, then pretty-printed code differences between the file-based method and the in-memory version, if any, will be shown.'].

	^ outerButton
