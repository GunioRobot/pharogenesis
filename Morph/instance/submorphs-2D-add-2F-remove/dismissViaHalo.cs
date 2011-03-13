dismissViaHalo
	"The user has clicked in the delete halo-handle.  This provides a hook in case some concomitant action should be taken, or if the particular morph is not one which should be put in the trash can, for example."

	| cmd |
	self setProperty: #lastPosition toValue: self positionInWorld.
	self dismissMorph.
	Preferences preserveTrash ifTrue: [ 
		Preferences slideDismissalsToTrash
			ifTrue:[self slideToTrash: nil]
			ifFalse:[TrashCanMorph moveToTrash: self].
	].

	cmd _ Command new cmdWording: 'dismiss ' translated, self externalName.
	cmd undoTarget: ActiveWorld selector: #reintroduceIntoWorld: argument: self.
	cmd redoTarget: ActiveWorld selector: #onceAgainDismiss: argument: self.
	ActiveWorld rememberCommand: cmd