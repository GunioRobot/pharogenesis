fromMyServerLoad: otherProjectName
	| servers pair pr strm pvm proj projViewer |
	"If a newer version of me is on the server, load it."

	(pr _ Project named: otherProjectName) ifNotNil: ["it appeared"
		^ pr enter].
	(servers _ self serverList) isEmpty 
		ifTrue: [^ self inform: 
			'Current project does not know a server either.'].
	pair _ self class mostRecent: otherProjectName onServer: servers first.
	pair first ifNil: [
		pvm _ ProjectViewMorph newMorphicProjectOn: nil.
		pvm _ pvm findA: ProjectViewMorph.
		(proj _ pvm project) changeSet name: otherProjectName.
		projViewer _ self findProjectView: otherProjectName.
		proj setParent: Project current.
		(projViewer owner isKindOf: SystemWindow) ifTrue: [
				projViewer owner model: proj].
		^ projViewer project: proj].

	strm _ servers first oldFileNamed: pair first.
	self installRemoteFrom: strm named: otherProjectName.