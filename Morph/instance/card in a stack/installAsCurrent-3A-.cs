installAsCurrent: anInstance
	"Install anInstance as the one currently viewed in the receiver.  Dock up all the morphs in the receiver which contain data rooted in the player instance to the instance data.  Run any 'opening' scripts that pertain."

	| fieldList itsFocus |
	self player == anInstance ifTrue: [^ self].
	fieldList _ self allMorphs select:
		[:aMorph | (aMorph wouldAcceptKeyboardFocusUponTab) and: [aMorph isLocked not]].
	self currentWorld hands do:
		[:aHand | (itsFocus _ aHand keyboardFocus) notNil ifTrue:
			[(fieldList includes: itsFocus) ifTrue: [aHand newKeyboardFocus: nil]]].

	self player uninstallFrom: self.  "out with the old"

	anInstance installPrivateMorphsInto: self.
	self changed.
	anInstance costume: self.
	self player: anInstance.
	self player class variableDocks do:
		[:aVariableDock | aVariableDock dockMorphUpToInstance: anInstance].
	self currentWorld startSteppingSubmorphsOf: self