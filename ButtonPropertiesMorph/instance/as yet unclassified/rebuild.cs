rebuild

	| buttonColor |

	myTarget ensuredButtonProperties.
	"self targetProperties unlockAnyText."	"makes styling the text easier"

	self removeAllMorphs.
	self addAColumn: {
		self lockedString: ('Button Properties for {1}' translated format: {myTarget name}).
	}.
	self addAColumn: {
		self paneForButtonTargetReport.
	}.
	self addAColumn: {
		self paneForButtonSelectorReport.
	}.

	self addAColumn: {
		(self inARow: {
			self paneForActsOnMouseDownToggle.
			self paneForActsOnMouseUpToggle.
		})  hResizing: #shrinkWrap.
	}.

	self addAColumn: {
		self inARow: {
			(self paneForWantsFiringWhileDownToggle) hResizing: #shrinkWrap.
			self paneForRepeatingInterval.
		}.
	}.

	self addAColumn: {
		(self inAColumn: {
			self paneForWantsRolloverToggle.
		}) hResizing: #shrinkWrap.
	}.
	self addARow: {
		self paneForMouseOverColorPicker.
		self paneForMouseDownColorPicker.
	}.
	self addARow: {
		self paneForChangeMouseEnterLook.
		self paneForChangeMouseDownLook.
	}.

	buttonColor _ color lighter.
	self addARow: {
		self inAColumn: {
			self addARow: {
				self 
					buttonNamed: 'Add label' translated action: #addTextToTarget color: buttonColor
					help: 'add some text to the button' translated.
				self 
					buttonNamed: 'Remove label' translated action: #removeTextFromTarget color: buttonColor
					help: 'remove text from the button' translated.
			}.
			self addARow: {
				self 
					buttonNamed: 'Accept' translated action: #doAccept color: buttonColor
					help: 'keep changes made and close panel' translated.
				self 
					buttonNamed: 'Cancel' translated action: #doCancel color: buttonColor
					help: 'cancel changes made and close panel' translated.
				self transparentSpacerOfSize: 10@3.
				self 
					buttonNamed: 'Main' translated action: #doMainProperties color: color lighter 
					help: 'open a main properties panel for the morph' translated.
				self 
					buttonNamed: 'Remove' translated action: #doRemoveProperties color: color lighter 
					help: 'remove the button properties of this morph' translated.
			}.
		}.
		self inAColumn: {
			self paneForChangeVisibleMorph
		}.
	}.
