changesMenu
	"Build the changes menu for the world."
	| menu |
	menu _ (MenuMorph entitled: 'changes...') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'file out current change set' target: Utilities action: #fileOutChanges.
	menu balloonTextForLastItem: 'Write the current change set out to a file whose name reflects the change set name and the current date & time.'.

	menu add: 'create new change set...' target: ChangeSorter action: #newChangeSet.
	menu balloonTextForLastItem: 'Create a new change set and make it the current one.'.

	menu add: 'browse changed methods' action: #browseChangedMessages.
	menu balloonTextForLastItem: 'Open a message-list browser showing all methods in the current change set'.

	menu add: 'check change set for slips' target: Smalltalk changes action: #lookForSlips.
	menu balloonTextForLastItem: 'Check the current change set for halts, references to the Transcript, etc., and if any such thing is found, open up a message-list browser detailing all possible slips.'.


	menu addLine.
	menu add: 'simple change sorter' selector: #openChangeSorter: argument: 1.
	menu balloonTextForLastItem: 'Open a 3-paned changed-set viewing tool'.

	menu add: 'dual change sorter' selector: #openChangeSorter: argument: 2.
	menu balloonTextForLastItem: 'Open a change sorter that shows you two change sets at a time, making it easy to copy and move methods and classes between them.'.

	menu addLine.
	menu add: 'browse recent submissions' action: #openRecentChanges.
	menu balloonTextForLastItem: 'Open a message-list browser that shows the most recent methods that have been submitted.  If you submit changes within that browser, it will keep up-to-date, always showing the most recent submissions.'.

	menu add: 'recently logged changes...' 
		action: #openChangesLog.
	menu balloonTextForLastItem: 'Open a change-list browser on the latter part of the changes log.'.

	menu add: 'recent log file...'
		action: #fileForRecentLog.
	menu balloonTextForLastItem: 'Create a file holding the logged changes (going as far back as you wish), and open a window on that file.'.

	menu addLine.
	menu add: 'save world as morph file' action: #saveWorldInFile.
	menu balloonTextForLastItem: 'Save a file that, when reloaded, reconstitutes the current World.'.

	menu addLine.
	Project current isIsolated
	ifTrue: [menu add: 'propagate changes upward' action: #propagateChanges.
			menu balloonTextForLastItem: 'The changes made in this isolated project will propagate to projects up to the next isolation layer.']
	ifFalse: [menu add: 'isolate changes of this project' action: #beIsolated.
			menu balloonTextForLastItem: 'Isolate this project and its subprojects from the rest of the system.  Changes to methods here will be revoked when you leave this project.'].

	^ menu