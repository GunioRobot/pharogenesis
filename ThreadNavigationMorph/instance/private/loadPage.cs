loadPage
	| theProject projectInfo url gotoPage theBook |
	projectInfo := listOfPages at: currentIndex.
	url := projectInfo first.
	gotoPage := projectInfo at: 2 ifAbsent: [nil].
	[Project fromUrl: url] on: ProjectEntryNotification
		do: 
			[:ex | 
			self deleteCurrentPage.
			theProject := ex projectToEnter enterAsActiveSubprojectWithin: self world.
			theProject world showExpandedView.
			loadedProject := theProject.
			gotoPage ifNotNil: 
					[theBook := loadedProject world findA: BookMorph.
					theBook ifNotNil: [theBook goToPage: gotoPage]].
			^loadedProject]