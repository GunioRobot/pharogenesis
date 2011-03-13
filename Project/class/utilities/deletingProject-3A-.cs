deletingProject: outgoingProject

	ImageSegment allSubInstancesDo: [:seg |
		seg ifOutPointer: outgoingProject thenAllObjectsDo: [:obj |
			(obj isKindOf: ProjectViewMorph) ifTrue: [
				obj deletingProject: outgoingProject.  obj abandon].
			obj class == Project ifTrue: [obj deletingProject: outgoingProject]]].
	Project allProjects do: [:p | p deletingProject: outgoingProject].	"ones that are in"
	ProjectViewMorph allSubInstancesDo: [:p | 
		p deletingProject: outgoingProject.
		p project == outgoingProject ifTrue: [p abandon]].

	AllProjects := self allProjects copyWithout: outgoingProject.