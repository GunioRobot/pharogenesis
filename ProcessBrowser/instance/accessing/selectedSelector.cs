selectedSelector
	"Answer the class in which the currently selected context's method was  
	found."
	^ selectedSelector
		ifNil: [selectedSelector _ selectedContext receiver
				ifNil: [| who | 
					who _ selectedContext method.
					selectedClass _ who first.
					who last]
				ifNotNil: [selectedContext methodSelector]]