projectThumbnail
	"Offer the user a menu of project names. Attach to the hand a thumbnail of the project the user selects."

	| menu projName pr |
	menu _ MVCMenuMorph entitled: 'Select Project'.
	menu add: (Project current name, ' (current)') action: Project current name.
	menu addLine.
	Project allNames do: [:n | menu add: n action: n].
	projName _ menu invokeAt: self position in: self world.
	projName ifNotNil:
		[(pr _ Project named: projName) 
			ifNotNil: [self attachMorph: (ProjectViewMorph on: pr)]
			ifNil: [self inform: 'can''t seem to find that project']].