deleteProjectNamed: aString 
	| project |


	project := Project named: aString.
	project isNil
		ifFalse: [""
			project removeChangeSetIfPossible.
			ProjectHistory forget: project.
			Project deletingProject: project].
	""
	(SystemWindow
		windowsIn: World
		satisfying: [:each | each label = aString])
		do: [:each | 
			each model: nil.
			each delete].
	""
	ChangeSorter
		removeChangeSetsNamedSuchThat: [:csName | csName = aString]