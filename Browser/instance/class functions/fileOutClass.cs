fileOutClass
	"Print a description of the selected class onto a file whose name is the 
	category name followed by .st."

	classListIndex ~= 0 ifTrue: [self selectedClass fileOut]