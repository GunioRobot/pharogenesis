threadOfNoProjects

	| nameList nav |

	nameList _ { {CurrentProjectRefactoring currentProjectName} }.
	nav _ self class basicNew.
	nav
		listOfPages: nameList;
		threadName: '';
		initialize.
	nav editThisThread.
