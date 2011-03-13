projectHierarchy
	"Answer a string representing all the projects in the system in hierarchical order"

	^ String streamContents:
		[:aStream |
			self topProject addSubProjectNamesTo: aStream indentation: 0] 

"Project projectHierarchy"