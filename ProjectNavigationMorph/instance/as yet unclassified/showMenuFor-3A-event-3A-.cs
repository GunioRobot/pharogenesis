showMenuFor: aSymbol event: evt

	aSymbol == #publishProject ifTrue: [
		self doPublishButtonMenuEvent: evt.
		^true		"we did show the menu"
	].
	aSymbol == #findAProject ifTrue: [
		self doFindButtonMenuEvent: evt.
		^true		"we did show the menu"
	].
	^false
