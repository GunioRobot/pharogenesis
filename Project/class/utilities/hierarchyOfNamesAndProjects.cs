hierarchyOfNamesAndProjects
	"Answer a list of all project names, with each entry preceded by white space commensurate with its depth beneath the top project"
	
	^ self allProjectsOrdered collect:
		[:project | Array with: project nameAdjustedForDepth with: project]