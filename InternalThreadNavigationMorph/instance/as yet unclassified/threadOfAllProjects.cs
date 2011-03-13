threadOfAllProjects

	| nameList nav |

	nameList _ Project allMorphicProjects collect: [ :each | {each name}].
	nav _ self class basicNew.
	nav
		listOfPages: nameList;
		threadName: '';
		initialize.
	nav editThisThread.
