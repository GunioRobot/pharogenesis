keystroke: keyEvent
	"Key struck on the keyboard. Find out which one and, if special, carry 
	out the associated special action. Otherwise, add the character to the 
	stream of characters.  Undoer & Redoer: see closeTypeIn."

	| typeAhead |
	typeAhead := (String new: 128) writeStream.
	self deselect.
	(self dispatchOnKeyEvent: keyEvent with: typeAhead)
		ifTrue: [
			self doneTyping.
			self setEmphasisHere.
			^self selectAndScroll; updateMarker].
	self openTypeIn.

	self hasSelection ifTrue: "save highlighted characters"
		[UndoSelection := self selection]. 
	self zapSelectionWith: 
			(Text string: typeAhead contents emphasis: emphasisHere).
	typeAhead reset.
	self unselect.
	self selectAndScroll.
	self updateMarker