addReference: aReference workingCopy: aWorkingCopy repositories: anArray 
	super addReference: aReference workingCopy: aWorkingCopy repositories: anArray.
	self model addVersion: (self findVersion: aReference workingCopy: aWorkingCopy repositories: anArray)