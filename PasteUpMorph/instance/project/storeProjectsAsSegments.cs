storeProjectsAsSegments
	"Force my sub-projects out to disk"

submorphs do: [:sub |
	(sub isKindOf: SystemWindow) ifTrue: [
		(sub model isKindOf: Project) ifTrue: [
			sub model storeSegment]]].	"OK if was already out"