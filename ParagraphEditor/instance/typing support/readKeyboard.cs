readKeyboard
	"Key struck on the keyboard. Find out which one and, if special, carry 
	out the associated special action. Otherwise, add the character to the 
	stream of characters.  Undoer & Redoer: see closeTypeIn."

	| typeAhead char |
	typeAhead _ WriteStream on: (String new: 128).
	[sensor keyboardPressed] whileTrue: 
		[self deselect.
		 [sensor keyboardPressed] whileTrue: 
			[char _ sensor keyboardPeek.
			(self dispatchOnCharacter: char with: typeAhead) ifTrue:
				[self doneTyping.
				self setEmphasisHere.
				^self selectAndScroll; updateMarker].
			self openTypeIn].
		self hasSelection ifTrue: "save highlighted characters"
			[UndoSelection _ self selection]. 
		self zapSelectionWith: 
			(Text string: typeAhead contents emphasis: emphasisHere).
		typeAhead reset.
		self unselect.
		sensor keyboardPressed ifFalse: 
			[self selectAndScroll.
			sensor keyboardPressed
				ifFalse: [self updateMarker]]]