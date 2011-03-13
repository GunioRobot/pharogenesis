navigationKey: event
	"Check for active window navigation."
	
	(event commandKeyPressed and: [event shiftPressed not]) ifTrue: [
		(UITheme current openTasklist: event) ifTrue: [^true].
		event keyCharacter = Character arrowLeft
			ifTrue: [self navigateWindowBackward. 
					^true].
		event keyCharacter = Character arrowRight
			ifTrue: [self navigateWindowForward. 
					^true]].
	^false