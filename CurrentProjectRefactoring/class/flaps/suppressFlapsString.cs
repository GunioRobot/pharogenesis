suppressFlapsString
	"Answer a string characterizing whether flaps are suppressed 
	at the moment or not"
	
	self deprecated: 'CurrentProjectRefactoring is deprecated'.
	
	^ (self currentFlapsSuppressed
		ifTrue: ['<no>']
		ifFalse: ['<yes>']), 'show shared tabs (F)' translated