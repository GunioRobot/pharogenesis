selectedClass
	"Answer the class that is currently selected. Answer nil if no selection 
	exists."

	| name envt |
	(name _ self selectedClassName) ifNil: [^ nil].
	"(envt _ self selectedEnvironment) ifNil: [^ nil]."
	envt_(Smalltalk environmentForCategory: self selectedSystemCategoryName).
	^ envt at: name