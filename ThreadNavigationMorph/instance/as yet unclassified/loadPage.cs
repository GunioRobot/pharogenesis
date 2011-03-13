loadPage

	| theProject projectInfo url gotoPage theBook |

	projectInfo _ listOfPages at: currentIndex.
	url _ projectInfo at: 1.
	gotoPage _ projectInfo at: 2 ifAbsent: [nil].
	[
		[Project fromUrl: url]
			on: ProjectEntryNotification
			do: [ :ex | 
				self deleteCurrentPage.
				theProject _ ex projectToEnter enterAsActiveSubprojectWithin: self world.
				theProject world showExpandedView.
				loadedProject _ theProject.
				gotoPage ifNotNil: [
					theBook _ loadedProject world findA: BookMorph.
					theBook ifNotNil: [
						theBook goToPage: gotoPage
					].
				].
				^loadedProject
			].
	]
		on: RequestCurrentWorldNotification
		do: [ :ex | ex resume: self world ]
