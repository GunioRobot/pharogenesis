copyFromRootsLocalFileFor: rootArray sizeHint: segSize
	"If the roots include a World, add its Player classes to the roots."
	| newRoots |

	arrayOfRoots _ rootArray.
	[(newRoots _ self rootsIncludingPlayers) == nil] whileFalse: [
		arrayOfRoots _ newRoots].		"world, presenter, and all Player classes"
	Smalltalk forgetDoIts.  
	self copyFromRoots: arrayOfRoots sizeHint: segSize.
