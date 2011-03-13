initializeFor: aPresenter
	"Initialize the receiver as a tool which shows, and allows the user to change the status of, all the instantiations of all the user-written scripts in the world"

	| aButton aRow outerButton |
	presenter _ aPresenter.
	showingOnlyActiveScripts _ true.
	showingAllInstances _ true.
	self color: Color brown muchLighter muchLighter; wrapCentering: #center; cellPositioning: #topCenter; vResizing: #shrinkWrap; hResizing: #shrinkWrap.
	self useRoundedCorners.
	self borderWidth: 4; borderColor: Color brown darker.
	self addMorph: ScriptingSystem scriptControlButtons.
	aButton _ SimpleButtonMorph new target: aPresenter; actionSelector: #updateContentsFor:; arguments: (Array with: self); label: 'Update'; color: Color lightYellow; actWhen: #buttonDown.
	aButton setBalloonText: 'Press here to get the lists of scripts updated'.
	aRow _ AlignmentMorph newRow listCentering: #center; color: Color transparent.
	aRow addMorphBack: aButton.

	outerButton _ AlignmentMorph newRow.
	outerButton wrapCentering: #center; cellPositioning: #leftCenter.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleWhetherShowingOnlyActiveScripts;
		getSelector: #showingOnlyActiveScripts.
	outerButton addMorphBack: (StringMorph contents: 'tickers only') lock.
	outerButton setBalloonText: 'If checked, then only scripts that are paused or ticking will be shown'.
	aRow addMorphBack: outerButton.

	outerButton _ AlignmentMorph newRow.
	outerButton wrapCentering: #center; cellPositioning: #leftCenter.
	outerButton color:  Color transparent.
	outerButton hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	outerButton addMorph: (aButton _ UpdatingThreePhaseButtonMorph checkBox).
	aButton
		target: self;
		actionSelector: #toggleWhetherShowingAllInstances;
		getSelector: #showingAllInstances.
	outerButton addMorphBack: (StringMorph contents: 'all instances') lock.
	outerButton setBalloonText: 'If checked, then status of all instances will be shown, but if not checked, scripts for only one exemplar of each uniclass will be shown'.
	aRow addMorphBack: outerButton.

	self addMorphBack: aRow.
	aPresenter updateContentsFor: self.
	self layoutChanged.