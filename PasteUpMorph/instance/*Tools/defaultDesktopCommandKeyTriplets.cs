defaultDesktopCommandKeyTriplets
	"Answer a list of triplets of the form
		<key> <receiver> <selector>   [+ optional fourth element, a <description> for use in desktop-command-key-help]
that will provide the default desktop command key handlers.  If the selector takes an argument, that argument will be the command-key event"

	| noviceKeys expertKeys |

	noviceKeys := {
		{ $o.	ActiveWorld.						#activateObjectsTool.						'Activate the "Objects Tool"'}.
		{ $r.	ActiveWorld.						#restoreMorphicDisplay.					'Redraw the screen'}.		
		{ $z.	self.								#undoOrRedoCommand.					'Undo or redo the last undoable command'}.
		{ $F.	Project current.					#toggleFlapsSuppressed.					'Toggle the display of flaps'}.
		{ $N.	self.								#toggleClassicNavigatorIfAppropriate.	'Show/Hide the classic Navigator, if appropriate'}.
		{ $M.	self.								#toggleShowWorldMainDockingBar.		'Show/Hide the Main Docking Bar'}.
	}.

	Preferences noviceMode
			ifTrue:[^ noviceKeys].

	expertKeys := {
		{ $b.	SystemBrowser.					#defaultOpenBrowser.						'Open a new System Browser'}.
		{ $k.	StringHolder.					#open.										'Open a new, blank Workspace'}.
		{ $m.	self.								#putUpNewMorphMenu.					'Put up the "New Morph" menu'}.
		{ $t.	self.	 							#findATranscript:.							'Make a System Transcript visible'}.
		{ $w.	SystemWindow.					#closeTopWindow.							'Close the topmost window'}.

		{ $C.	self.								#findAChangeSorter:.						'Make a Change Sorter visible'}.

		{ $L.	self.								#findAFileList:.								'Make a File List visible'}.
		{ $P.	self.								#findAPreferencesPanel:.					'Activate the Preferences tool'}.
		{ $R.	self. 								#openRecentSubmissionsBrowser:.		'Make a Recent Submissions browser visible'}.

		{ $W.	self. 								#findAMessageNamesWindow:.			'Make a MessageNames tool visible'}.
		{ $Z.	ChangeList. 						#browseRecentLog.							'Browse recently-logged changes'}.

		{ $\.	SystemWindow. 					#sendTopWindowToBack.					'Send the top window to the back'}.
	}.

	^ noviceKeys, expertKeys
