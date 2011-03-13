fillNavigatorOn: main 
	"main addLine."
	main addDefaultSpace.
	""
	main
		addMorphBack: (self
				createButtonIcon: self backIcon
				help: 'Previous project'
				selector: #previousProject).
	main
		addMorphBack: (self
				createButtonIcon: self jumpIcon
				help: 'Put up a list of all projects, letting me choose one to go to'
				selector: #jumpToProject).
	main
		addMorphBack: (self
				createButtonIcon: self forwardIcon
				help: 'Next project'
				selector: #nextProject).
	main
		addMorphBack: (self
				createButtonIcon: self openIcon
				help: 'Find any file'
				selector: #findAnyFile).
Preferences tinyDisplay ifFalse:[""
	main
		addMorphBack: (self
				createButtonIcon: self loadProjectIcon
				help: 'Find a project'
				selector: #findAProject)].
	main addDefaultSpace.
	main addSpacer.
	main
		addMorphBack: (self
				createButtonIcon: self projectIcon
				help: 'Start a new project'
				selector: #newProject).
	main
		addMorphBack: (self
				createButtonIcon: self paintIcon
				help: 'Make a painting'
				selector: #doNewPainting).
	main
		addMorphBack: (self
				createButtonIcon: self objectCatalogIcon
				help: 'Open the objects catalog'
				selector: #activateObjectsTool).
Preferences tinyDisplay ifFalse:[""
	main
		addMorphBack: (self
				createButtonIcon: self publishIcon
				help: 'Publish the current project'
				selector: #publishProject)].
	""
	main addDefaultSpace