selectInverseClasses
	classesSelected := classes asSet 
		removeAll: classesSelected;
		yourself.
	self changed: #classSelected; changed: #hasRunnable.