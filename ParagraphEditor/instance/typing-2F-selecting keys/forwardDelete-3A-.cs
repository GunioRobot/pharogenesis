forwardDelete: characterStream
	"Delete forward over the next character.
	  Make Undo work on the whole type-in, not just the one char."
	| startIndex usel upara uinterval ind |
	startIndex _ startBlock stringIndex.
	startIndex > paragraph text size ifTrue:
		[sensor keyboard.
		^ false].
	startIndex = stopBlock stringIndex ifFalse:
		["there was a selection"
		"Just like regular Backspace -- delete the selection"
		^ self backspace: characterStream].
	"Null selection - do the delete forward"
	beginTypeInBlock == nil	"no previous typing.  openTypeIn"
		ifTrue: [self openTypeIn. UndoSelection _ self nullText].
	uinterval _ UndoInterval deepCopy.
	"umes _ UndoMessage deepCopy.	Set already by openTypeIn"
	"usel _ UndoSelection deepCopy."
	upara _ UndoParagraph deepCopy.
	sensor keyboard.
	self selectFrom: startIndex to: startIndex.
	self replaceSelectionWith: self nullText.
	self selectFrom: startIndex to: startIndex-1.
	UndoParagraph _ upara.  UndoInterval _ uinterval.
	UndoMessage selector == #noUndoer ifTrue: [
		(UndoSelection isText) ifTrue: [
			usel _ UndoSelection.
			ind _ startIndex. "UndoInterval startIndex"
			usel replaceFrom: usel size + 1 to: usel size with:
				(UndoParagraph text copyFrom: ind to: ind).
			UndoParagraph text replaceFrom: ind to: ind with:
self nullText]].
	^false