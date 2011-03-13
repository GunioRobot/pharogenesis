moreCommands

	| allThreads aMenu others |

	allThreads _ self class knownThreads.
	aMenu _ MenuMorph new defaultTarget: self.
	others _ (allThreads keys reject: [ :each | each = threadName]) asSortedCollection.
	others do: [ :each |
		aMenu add: 'switch to <',each,'>' selector: #switchToThread: argument: each.
	].
	aMenu 
		add: 'switch to recent projects' action: #getRecentThread;
		addLine;
		add: 'thread of all projects' action: #threadOfAllProjects;
		add: 'thread of no projects' action: #threadOfNoProjects;
		add: 'edit this thread' action: #editThisThread;
		addLine;
		add: 'First project in thread' action: #firstPage;
		add: 'Last project in thread' action: #lastPage;
		add: 'jump within this thread' action: #jumpWithinThread;
		add: 'insert new project' action: #insertNewProject;
		addLine;
		add: 'simply close this navigator' action: #delete.

	aMenu popUpEvent: self world primaryHand lastEvent in: self world