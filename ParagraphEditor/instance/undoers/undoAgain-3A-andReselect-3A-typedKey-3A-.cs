undoAgain: indices andReselect: home typedKey: wasTypedKey
	"The last command was again.  Undo it. Redoer: itself."

	| findSize substText index subject |
	(self isRedoing & wasTypedKey) ifTrue: "redelete search key"
		[self selectInterval: home.
		self zapSelectionWith: self nullText].

	findSize _ (self isRedoing ifTrue: [FindText] ifFalse: [ChangeText]) size.
	substText _ self isUndoing ifTrue: [FindText] ifFalse: [ChangeText].
	(self isUndoing ifTrue: [indices size to: 1 by: -1] ifFalse: [1 to: indices size]) do:
		[:i |
		index _ indices at: i.
		(subject _ index to: index + findSize - 1) = self selectionInterval ifFalse:
			[self selectInterval: subject].
		FindText == ChangeText ifFalse: [self zapSelectionWith: substText]].

	self isUndoing
		ifTrue:  "restore selection to where it was when 'again' was invoked"
			[wasTypedKey
				ifTrue: "search started by typing key at a caret; restore it"
					[self selectAt: home first.
					self zapSelectionWith: FindText.
					self selectAt: home last + 1]
				ifFalse: [self selectInterval: home]].

	self undoMessage: UndoMessage forRedo: self isUndoing