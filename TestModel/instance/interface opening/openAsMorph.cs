openAsMorph
	"doIt: [TestModel new openAsMorph]"

	| topWindowM runButtonM detailsTextM failureListM errorListM |

	self updateColorSelector: #updateColorM.

	"=== build the parts ... ==="
	(topWindowM := SystemWindow labelled: self windowLabel)
		model: self.
	self patternTextM: (PluggableTextMorph
		on: self
		text: #patternText
		accept: #patternText:
		readSelection: nil
		menu: #patternHistoryMenu:).
	self patternTextM setBalloonText: self balloonPatternText.
	runButtonM := PluggableButtonMorph
		on: self
		getState: #runButtonState
		action: #runTests
		label: #runButtonLabel.
	runButtonM
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		onColor: self runButtonColor
		offColor: self runButtonColor.
	runButtonM setBalloonText: self balloonRunButton.
	self summaryTextM: (PluggableTextMorph
		on: self
		text: #summaryText
		accept: nil).
	self summaryTextM setBalloonText: self balloonSummaryText.
	detailsTextM := PluggableTextMorph
		on: self
		text: #detailsText
		accept: nil.
	detailsTextM setBalloonText: self balloonDetailsText.
	failureListM := PluggableListMorph
		on: self
		list: #failureList
		selected: #failureListSelectionIndex
		changeSelected: #failureListSelectionIndex:.
	failureListM setBalloonText: self balloonFailureList.
	errorListM := PluggableListMorph
		on: self
		list: #errorList
		selected: #errorListSelectionIndex
		changeSelected: #errorListSelectionIndex:.
	errorListM setBalloonText: self balloonErrorList.

	"=== assemble the whole ... ==="
	topWindowM
		addMorph: self patternTextM frame: (0.0@0.0 extent: 1.0@0.1);
		addMorph: runButtonM frame: (0.0@0.1 extent: 0.2@0.1);
		addMorph: self summaryTextM frame: (0.2@0.1 extent: 0.8@0.1);
		addMorph: detailsTextM frame: (0.0@0.2 extent: 1.0@0.1);
		addMorph: failureListM frame: (0.0@0.3 extent: 1.0@0.35);
		addMorph: errorListM frame: (0.0@0.65 extent: 1.0@0.35).

	"=== open it ... ==="
	topWindowM openInWorldExtent: 250@200.
	^topWindowM