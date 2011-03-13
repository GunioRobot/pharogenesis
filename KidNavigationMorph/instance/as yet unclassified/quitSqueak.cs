quitSqueak

	| newProjects limit now msg response |

	Preferences checkForUnsavedProjects ifFalse: [^super quitSqueak].
	PreExistingProjects ifNil: [^super quitSqueak].
	limit _ 5 * 60.
	now _ Time totalSeconds.
	newProjects _ Project allProjects reject: [ :each | PreExistingProjects includes: each].
	newProjects _ newProjects reject: [ :each | 
		((each lastSavedAtSeconds ifNil: [0]) - now) abs < limit
	].
	newProjects isEmpty ifTrue: [^super quitSqueak].
	msg _ String streamContents: [ :strm |
		strm nextPutAll: 'There are some project(s)
that have not been saved recently:
----
'.
		newProjects do: [ :each | strm nextPutAll: each name; cr].
		strm nextPutAll: '----
What would you like to do?'
	].
	response _ PopUpMenu 
		confirm: msg
		trueChoice: 'Go ahead and QUIT'
		falseChoice: 'Wait, let me save them first'.
	response ifTrue: [^super quitSqueak].

