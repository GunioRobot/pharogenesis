verifyContents
	"Verify the contents of the receiver, reconstituting if necessary.  Called whenever window is reactivated, to react to possible structural changes.  Also called periodically in morphic if the smartUpdating preference is true"
	| newList existingSelection anIndex oldList |
	oldList _ list ifNil: [ #() ].
	newList _ self getList.
	((oldList == newList) "fastest" or: [oldList = newList]) ifTrue: [^ self].
	self flash.  "list has changed beneath us; give the user a little visual feedback that the contents of the pane are being updated."
	existingSelection _ self selectionIndex > 0 ifTrue: [ oldList at: self selectionIndex ] ifFalse: [ nil ].
	self updateList.
	(existingSelection notNil and: [(anIndex _ list indexOf: existingSelection asStringOrText ifAbsent: [nil]) notNil])
		ifTrue:
			[model noteSelectionIndex: anIndex for: getListSelector.
			self selectionIndex: anIndex]
		ifFalse:
			[self changeModelSelection: 0]