moreCommands
	"Put up a menu of options"

	| allThreads aMenu others target |
	allThreads _ self class knownThreads.
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'navigation' translated.
	aMenu addStayUpItem.
	self flag: #deferred.  "Probably don't want that stay-up item, not least because the navigation-keystroke stuff is not dynamically handled"
	others _ (allThreads keys reject: [ :each | each = threadName]) asSortedCollection.
	others do: [ :each |
		aMenu add: ('switch to <{1}>' translated format:{each}) selector: #switchToThread: argument: each].
	aMenu addList: {
		{'switch to recent projects' translated.  #getRecentThread}.
		#-.
		{'create a new thread' translated.  #threadOfNoProjects}.
		{'edit this thread' translated.  #editThisThread}.
		{'create thread of all projects' translated.  #threadOfAllProjects}.
		#-.
		{'First project in thread' translated.  #firstPage}.
		{'Last project in thread' translated.  #lastPage}}.
	(target _ self currentIndex + 2) > listOfPages size ifFalse:
		[aMenu 
			add: ('skip over next project ({1})' translated format:{(listOfPages at: target - 1) first})
			action: #skipOverNext].
	aMenu addList: {
		{'jump within this thread' translated.  #jumpWithinThread}.
		{'insert new project' translated.  #insertNewProject}.
		#-.
		{'simply close this navigator' translated.  #delete}.
		{'destroy this thread' translated. #destroyThread}.
		#-}.

	(ActiveWorld keyboardNavigationHandler == self)
		ifFalse:
			[aMenu add: 'start keyboard navigation with this thread' translated action: #startKeyboardNavigation]
		ifTrue:
			[aMenu add: 'stop keyboard navigation with this thread' translated action: #stopKeyboardNavigation].

	aMenu popUpInWorld