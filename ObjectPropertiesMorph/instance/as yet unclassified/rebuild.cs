rebuild

	self removeAllMorphs.
	self addARow: {
		self lockedString: ('Properties for {1}' translated format: {myTarget name}).
	}.
	self addARow: {
		self inAColumn: {
			self paneForCornerRoundingToggle.
			self paneForStickinessToggle.
			self paneForLockedToggle.
		}.
	}.

	self addARow: {
		self paneForMainColorPicker.
		self paneFor2ndGradientColorPicker.
	}.
	self addARow: {
		self paneForBorderColorPicker.
		self paneForShadowColorPicker.
	}.

	self addARow: {
		self 
			buttonNamed: 'Accept' translated action: #doAccept color: color lighter 
			help: 'keep changes made and close panel' translated.
		self 
			buttonNamed: 'Cancel' translated action: #doCancel color: color lighter 
			help: 'cancel changes made and close panel' translated.
	}, self rebuildOptionalButtons.

	thingsToRevert _ Dictionary new.
	"thingsToRevert at: #fillStyle: put: myTarget fillStyle."
	myTarget isSystemWindow ifTrue: [
		thingsToRevert at: #setWindowColor: put: myTarget paneColorToUse
	].
	thingsToRevert at: #hasDropShadow: put: myTarget hasDropShadow.
	thingsToRevert at: #shadowColor: put: myTarget shadowColor.
	(myTarget respondsTo: #borderColor:) ifTrue: [
		thingsToRevert at: #borderColor: put: myTarget borderColor.
	].

	thingsToRevert at: #borderWidth: put: myTarget borderWidth.
	thingsToRevert at: #cornerStyle: put: myTarget cornerStyle.
	thingsToRevert at: #sticky: put: myTarget isSticky.
	thingsToRevert at: #lock: put: myTarget isLocked.
