projectThumbnail
	"Offer the user a menu of project names. Attach to the hand a thumbnail of the project the user selects."

	| menu projName pr |
	menu _ CustomMenu new.
	menu 
		add: (CurrentProjectRefactoring currentProjectName, ' (current)') 
		action: CurrentProjectRefactoring currentProjectName.
	menu addLine.
	Project allNames do: [:n | menu add: n action: n].
	projName _ menu startUpWithCaption: 'Select a project'.
	projName ifNotNil:
		[(pr _ Project named: projName) 
			ifNotNil: [myHand attachMorph: (ProjectViewMorph on: pr)]
			ifNil: [self inform: 'can''t seem to find that project']].