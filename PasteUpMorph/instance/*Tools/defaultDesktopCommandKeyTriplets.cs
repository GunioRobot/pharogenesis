defaultDesktopCommandKeyTriplets
	"Answer a list of triplets of the form
		<key> <receiver> <selector>   [+ optional fourth element, a <description> for use in desktop-command-key-help]
that will provide the default desktop command key handlers.  If the selector takes an argument, that argument will be the command-key event"

	^ {
		{ $r.	ActiveWorld.						#restoreMorphicDisplay.					'Redraw the screen'}.		
		{ $z.	self.								#undoOrRedoCommand.					'Undo or redo the last undoable command'}.
		{ $b.	SystemBrowser.					#defaultOpenBrowser.						'Open a new System Browser'}.
		{ $k.	StringHolder.					#open.										'Open a new, blank Workspace'}.
		{ $t.		self.	 							#findATranscript:.							'Make a System Transcript visible'}.
		{ $C.	self.								#findAChangeSorter:.						'Make a Change Sorter visible'}.
		{ $R.	self. 								#openRecentSubmissionsBrowser:.		'Make a Recent Submissions browser visible'}.
		{ $W.	self. 								#findAMessageNamesWindow:.			'Make a MessageNames tool visible'}.
		{ $Z.	ChangeList. 						#browseRecentLog.							'Browse recently-logged changes'}.
		{ $\.	SystemWindow. 					#sendTopWindowToBack.					'Send the top window to the back'}.
	}.
