installRemoteFrom: strm named: otherProjectName
	| projViewer is proj |
	"Find the current ProjectViewMorph, fetch the project, install in ProjectViewMorph without changing size, and jump into new project."

	projViewer _ self findProjectView: otherProjectName.
	projViewer 
		ifNotNil: [is _ strm asUnZippedStream fileInObjectAndCode.
			(is isKindOf: ImageSegment) ifTrue: [
				proj _ is arrayOfRoots detect: [:mm | mm class == Project] 
							ifNone: [nil].
				proj ifNotNil: [proj versionFrom: strm.
					(projViewer project isKindOf: DiskProxy) ifFalse: [
						projViewer project changeSet name: ChangeSet defaultName].
					proj changeSet name: otherProjectName.
					proj setParent: Project current.
					(projViewer owner isKindOf: SystemWindow) ifTrue: [
						projViewer owner model: proj].
					projViewer project: proj.
					^ proj enter]]]
		ifNil: [(SelectionMenu confirm: 'No old thumbnail found. Debug?') 
					ifTrue: [self halt]].
	"replace with a new one"
	ProjectViewMorph openFromFile: strm.
		"Later check rest of servers if fails.  Still have list here"