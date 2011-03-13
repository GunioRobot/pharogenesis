selectedClass
	"Answer the class in which the currently selected context's method was  
	found."
	^ selectedClass
		ifNil: [selectedClass _ selectedContext receiver
				ifNil: [| who | 
					who _ selectedContext method who.
					selectedSelector _ who last.
					who first]
				ifNotNil: [selectedContext mclass]]