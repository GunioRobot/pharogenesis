skipOverNext
	
	| target |

	(target _ self currentIndex + 2) > listOfPages size ifTrue: [^Beeper beep].
	currentIndex _ target.
	self loadPageWithProgress.
