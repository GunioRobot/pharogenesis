pointersTo: anObject
	"Find all occurrences in the system of pointers to the argument anObject."
	"(Utilities pointersTo: Browser) inspect."
	
	self deprecated: 'Use ''PointerFinder pointersTo:'' instead.' on: '10 July 2009' in: #Pharo1.0.
	^ PointerFinder pointersTo: anObject except: #()
