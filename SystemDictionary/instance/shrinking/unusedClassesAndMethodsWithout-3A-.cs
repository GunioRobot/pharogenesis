unusedClassesAndMethodsWithout: classesAndMessagesPair 
	"Accepts and returns a pair: {set of class names. set of selectors}. 
	It is expected these results will be diff'd with the normally unused 
	results. "
	| classRemovals messageRemovals nClasses nMessages |
	(classRemovals := IdentitySet new) addAll: classesAndMessagesPair first.
	(messageRemovals := IdentitySet new) addAll: classesAndMessagesPair second.
	nClasses := nMessages := -1.
	
	[ "As long as we keep making progress..."
	classRemovals size > nClasses or: [ messageRemovals size > nMessages ] ] whileTrue: 
		[ "...keep trying for bigger sets of unused classes and selectors."
		nClasses := classRemovals size.
		nMessages := messageRemovals size.
		UIManager default 
			informUser: 'Iterating removals ' translated, (classesAndMessagesPair first isEmpty 
					ifTrue: [ 'for baseline...' translated]
					ifFalse: [ 'for ' translated, classesAndMessagesPair first first , ' etc...' ]) , Character cr asString , nClasses printString , ' classes, ' , nMessages printString , ' messages.
|
|'
			during: 
				[ "spacers move menu off cursor"
				classRemovals addAll: (self systemNavigation allUnusedClassesWithout: { 
							classRemovals.
							messageRemovals
						 }).
				messageRemovals addAll: (self systemNavigation allUnSentMessagesWithout: { 
							classRemovals.
							messageRemovals
						 }) ] ].
	^ { 
		classRemovals.
		(self systemNavigation allUnSentMessagesWithout: {  classRemovals. messageRemovals  })
	 }