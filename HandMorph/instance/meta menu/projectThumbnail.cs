projectThumbnail
	"Offer the user a menu of project names. Attach to the hand a thumbnail of the project the user selects."

	| menu projName |
	menu _ MVCMenuMorph entitled: 'Select Project'.
	Project allNames do: [:n | menu add: n action: n].
	projName _ menu invokeAt: self position in: self world.
	projName ifNotNil: [
		self attachMorph:
			(ProjectViewMorph on: (Project named: projName))].
