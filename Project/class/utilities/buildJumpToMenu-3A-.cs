buildJumpToMenu: menu
	"Make the supplied menu offer a list of potential projects, consisting of:
		*	The previous-project chain
		*	The next project, if any
		*	The parent project, if any
		*	All projects, alphabetically or hierarchically"

	| prev listed i next  toAdd |
	listed _ OrderedCollection with: CurrentProject.
	i _ 0.

	"The previous Project chain"
	prev _ CurrentProject previousProject.
	[(prev ~~ nil and: [(listed includes: prev) not])] whileTrue:
	  [i _ i + 1.
		listed add: prev.
		self 	addItem: prev name , ' (back ' , i printString , ')'
				toMenu: menu 
				selection: ('%back' , i printString) 
				project: prev.
		prev _ prev previousProject].
	i > 0 ifTrue: [menu addLine].


	"Then the next Project"
	(((next _ CurrentProject nextProject) ~~ nil) and: [(listed includes: next) not]) ifTrue:
		[self	addItem: (next name, ' (forward 1)') 
				toMenu: menu 
				selection: next name 
				project: next]. 
	next ~~ nil ifTrue: [menu addLine].

	"Then the parent"
	CurrentProject isTopProject ifFalse: 
		[self	addItem: CurrentProject parent name , ' (parent)' 
				toMenu: menu 
				selection: #parent 
				project: CurrentProject parent.
		  menu addLine].

	"Finally all the projects, in hierarchical or alphabetical order:"
	(Preferences alphabeticalProjectMenu
			ifTrue:
				[Project allNamesAndProjects]
			ifFalse:
				[Project hierarchyOfNamesAndProjects]) do:

		[:aPair | 
			toAdd _ aPair last isCurrentProject
				ifTrue:
				  [aPair first, ' (current)']
				ifFalse:
				  [aPair first].
			self	addItem: toAdd 
				toMenu: menu 
				selection: aPair first 
				project: aPair last].
	^ menu