askForDoits
	| menu choice choices |
	choices := #('do not process' 'at the beginning' 'at the end' 'cancel').
	menu _ SelectionMenu selections: choices.
	choice := nil.
	[choices includes: choice] whileFalse: [
		choice _ menu startUpWithCaption: 
'The package contains unprocessed doIts.
When would like to process those?'].
	^choices indexOf: choice