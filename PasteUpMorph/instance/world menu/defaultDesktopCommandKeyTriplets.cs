defaultDesktopCommandKeyTriplets
	"Answer a list of triplets of the form
		<key> <receiver> <selector>   [+ optional fourth element, a <description> for use in desktop-command-key-help]
that will provide the default desktop command key handlers.  If the selector takes an argument, that argument will be the command-key event"

	^ {
		{ $b.	SystemBrowser.					#defaultOpenBrowser.					'Open a new System Browser'}.
		{ $k.	Workspace.						#open.									'Open a new, blank Workspace'}.
		{ $m.	self.							#putUpNewMorphMenu.					'Put up the "New Morph" menu'}.
		{ $o.	ActiveWorld.					#activateObjectsTool.						'Activate the "Objects Tool"'}.
		{ $r.	ActiveWorld.					#restoreMorphicDisplay.					'Redraw the screen'}.		
		{ $t.		self. 							#findATranscript:.						'Make a System Transcript visible'}.
		{ $w.	SystemWindow.					#closeTopWindow.						'Close the topmost window'}.
		{ $z.	self.							#undoOrRedoCommand.					'Undo or redo the last undoable command'}.

		{ $C.	self.							#findAChangeSorter:.					'Make a Change Sorter visible'}.
		{ $F.	CurrentProjectRefactoring.		#currentToggleFlapsSuppressed.			'Toggle the display of flaps'}.

		{ $L.	self.							#findAFileList:.							'Make a File List visible'}.
		{ $N.    self.							#toggleClassicNavigatorIfAppropriate.	'Show/Hide the classic Navigator, if appropriate'}.
		{ $P.	self.							#findAPreferencesPanel:.				'Activate the Preferences tool'}.
		{ $R.	self. 							#openRecentSubmissionsBrowser:	.		'Make a Recent Submissions browser visible'}.

		{ $W.	self. 							#findAMessageNamesWindow:.			'Make a MessageNames tool visible'}.
		{ $Z.	ChangeList. 						#browseRecentLog.			'Browse recently-logged changes'}.

		{ $\.	SystemWindow. 					#sendTopWindowToBack.					'Send the top window to the back'}.}