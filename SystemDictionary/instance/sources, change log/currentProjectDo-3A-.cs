currentProjectDo: aBlock
	"So that code can work after removal of Projects"
	Smalltalk at: #Project ifPresent:
		[:projClass | aBlock value: projClass current].