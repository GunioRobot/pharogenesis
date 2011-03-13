forwardDelete: characterStream keyEvent: keyEvent
	"Delete forward over the next character.
	  Make Undo work on the whole type-in, not just the one char.
	wod 11/3/1998: If there was a selection use #zapSelectionWith: rather than #backspace: which was 'one off' in deleting the selection. Handling of things like undo or typeIn area were not fully considered."
	| startIndex usel upara uinterval ind stopIndex |
	startIndex := self mark.
	startIndex > paragraph text size
		ifTrue: [^ false].
	self hasSelection ifTrue:
		["there was a selection"
		self zapSelectionWith: self nullText.
		^ false].
	"Null selection - do the delete forward"
	beginTypeInBlock == nil	"no previous typing.  openTypeIn"
		ifTrue: [self openTypeIn. UndoSelection := self nullText].
	uinterval := UndoInterval deepCopy.
	upara := UndoParagraph deepCopy.
	stopIndex := startIndex.
	(keyEvent keyValue = 127 and: [keyEvent leftShiftDown])
		ifTrue: [stopIndex := (self nextWord: stopIndex) - 1].
	self selectFrom: startIndex to: stopIndex.
	self replaceSelectionWith: self nullText.
	self selectFrom: startIndex to: startIndex-1.
	UndoParagraph := upara.  UndoInterval := uinterval.
	UndoMessage selector == #noUndoer ifTrue: [
		(UndoSelection isText) ifTrue: [
			usel := UndoSelection.
			ind := startIndex. "UndoInterval startIndex"
			usel replaceFrom: usel size + 1 to: usel size with:
				(UndoParagraph text copyFrom: ind to: ind).
			UndoParagraph text replaceFrom: ind to: ind with:
self nullText]].
	^false