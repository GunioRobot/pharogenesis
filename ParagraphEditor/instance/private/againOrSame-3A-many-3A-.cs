againOrSame: useOldKeys many: many
	"Subroutine of search: and again.  If useOldKeys, use same FindText and ChangeText as before.  If many is true, do it repeatedly.  Created 1/26/96 sw by adding the many argument to #againOrSame."

	|  home indices wasTypedKey |

	home _ self selectionInterval.  "what was selected when 'again' was invoked"

	"If new keys are to be picked..."
	useOldKeys ifFalse: "Choose as FindText..."
		[FindText _ UndoSelection.  "... the last thing replaced."
		"If the last command was in another paragraph, ChangeText is set..."
		paragraph == UndoParagraph ifTrue: "... else set it now as follows."
			[UndoInterval ~= home ifTrue: [self selectInterval: UndoInterval]. "blink"
			ChangeText _ ((UndoMessage sends: #undoCutCopy:) and: [self hasSelection])
				ifTrue: [FindText] "== objects signal no model-locking by 'undo copy'"
				ifFalse: [self selection]]]. "otherwise, change text is last-replaced text"

	(wasTypedKey _ FindText size = 0)
		ifTrue: "just inserted at a caret"
			[home _ self selectionInterval.
			self replaceSelectionWith: self nullText.  "delete search key..."
			FindText _ ChangeText] "... and search for it, without replacing"
		ifFalse: "Show where the search will start"
			[home last = self selectionInterval last ifFalse:
				[self selectInterval: home]].

	"Find and Change, recording start indices in the array"
	indices _ WriteStream on: (Array new: 20). "an array to store change locs"
	[(self againOnce: indices) & many] whileTrue. "<-- this does the work"
	indices isEmpty ifTrue:  "none found"
		[self flash.
		wasTypedKey ifFalse: [^self]].

	(many | wasTypedKey) ifFalse: "after undo, select this replacement"
		[home _ self startIndex to:
			self startIndex + UndoSelection size - 1].

	self undoer: #undoAgain:andReselect:typedKey: with: indices contents with: home with: wasTypedKey