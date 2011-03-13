undoMessage: aMessage forRedo: aBoolean
	"Call this from an undoer/redoer to set up UndoMessage as the
	 corresponding redoer/undoer.  Also set up UndoParagraph, as well
	 as the state variable Undone.  It is assumed that UndoInterval has been
	 established (generally by zapSelectionWith:) and that UndoSelection has been
	 saved (generally by replaceSelectionWith: or replace:With:and:)."

	self isDoing ifTrue: [UndoParagraph _ paragraph].
	UndoMessage _ aMessage.
	Undone _ aBoolean