threadOfNoProjects

	| nameList nav |

	nameList _ { {Project current name} }.
	nav _ self class basicNew.
	nav
		listOfPages: nameList;
		threadName: '' index: nil;
		initialize.
	nav editThisThread.
