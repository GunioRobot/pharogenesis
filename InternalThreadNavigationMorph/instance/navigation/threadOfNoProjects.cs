threadOfNoProjects

	| nameList nav |

	nameList _ { {CurrentProjectRefactoring currentProjectName} }.
	nav _ self class basicNew.
	nav
		listOfPages: nameList;
		threadName: '' index: nil;
		initialize.
	nav editThisThread.
