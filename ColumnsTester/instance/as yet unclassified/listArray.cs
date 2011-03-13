listArray
	"Use #bigList here for a large four column list amd #smallList for a  
	short three column test."
	theList == nil ifTrue: [self populateInitialList].
	^ theList