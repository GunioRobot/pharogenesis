unusedClassesAndMethodsWithout: classesAndMessagesPair 
	"Accepts and returns a pair: {set of class names. set of selectors}. 
	It is expected these results will be diff'd with the normally unused 
	results. "
	| classRemovals messageRemovals nClasses nMessages |
	(classRemovals _ IdentitySet new) addAll: classesAndMessagesPair first.
	(messageRemovals _ IdentitySet new) addAll: classesAndMessagesPair second.
	nClasses _ nMessages _ -1.
	["As long as we keep making progress..."
	classRemovals size > nClasses
		or: [messageRemovals size > nMessages]]
		whileTrue: ["...keep trying for bigger sets of unused classes and selectors."
			nClasses _ classRemovals size.
			nMessages _ messageRemovals size.
			Utilities
				informUser: 'Iterating removals '
						, (classesAndMessagesPair first isEmpty
								ifTrue: ['for baseline...']
								ifFalse: ['for ' , classesAndMessagesPair first first , ' etc...']) , Character cr asString , nClasses printString , ' classes, ' , nMessages printString , ' messages.
|
|'
				during: ["spacers move menu off cursor"
					classRemovals
						addAll: (self systemNavigation allUnusedClassesWithout: {classRemovals. messageRemovals}).
					messageRemovals
						addAll: (self systemNavigation allUnSentMessagesWithout: {classRemovals. messageRemovals})]].
	^ {classRemovals. self systemNavigation allUnSentMessagesWithout: {classRemovals. messageRemovals}}