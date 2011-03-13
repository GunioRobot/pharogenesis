selectedClass
	"Answer the class that is currently selected. Answer nil if no selection 
	exists."

	| name |
	(name _ self selectedClassName) ifNil: [^ nil].
	^ Smalltalk at: name