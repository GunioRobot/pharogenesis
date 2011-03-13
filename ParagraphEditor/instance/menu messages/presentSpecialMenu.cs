presentSpecialMenu
	"Present a list of expressions, and if the user chooses one, evaluate it in the context of the receiver, a ParagraphEditor.  Primarily for debugging, this provides a convenient way to talk to the various views, controllers, and models associated with any text pane.  2/5/96 sw"

	| aList reply items |
	self flag: #scottPrivate.
	self terminateAndInitializeAround:
		[aList _ self specialMenuItems.
		reply _ (PopUpMenu labelArray: (items _ self specialMenuItems) lines: #()) startUp.
		reply = 0 ifTrue: [^ self].
		Utilities evaluate: (items at: reply) in: [] to: self]
	