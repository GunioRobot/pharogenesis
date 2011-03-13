pointersTo: anObject except: objectsToExclude 
	"Find all occurrences in the system of pointers to the argument
	anObject. Remove objects in the exclusion list from the
	results. "
	self deprecated: 'Use ''PointerFinder pointersTo:except:'' instead.' on: '10 July 2009' in: #Pharo1.0.
		
	^ PointerFinder pointersTo: anObject except: objectsToExclude 