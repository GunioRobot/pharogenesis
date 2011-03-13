printOutClass
	"Print a description of the selected class onto a file whose name is the 
	category name followed by .html."

Cursor write showWhile:
		[classListIndex ~= 0 ifTrue: [self selectedClass fileOutAsHtml: true]]