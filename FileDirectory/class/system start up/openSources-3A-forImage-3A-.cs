openSources: fullSourcesName forImage: imageName 
"We first do a check to see if a compressed version ofthe sources file is present.
Open the .sources file read-only after searching in:
a) the directory where the VM lives
b) the directory where the image came from
c) the DefaultDirectory (which is likely the same as b unless the SecurityManager has changed it).
"

	| sources fd sourcesName |
	(fullSourcesName endsWith: 'sources') ifTrue:
		["Look first for a sources file in compressed format."
		sources _ self openSources: (fullSourcesName allButLast: 7) , 'stc'
						forImage: imageName.
		sources ifNotNil: [^ CompressedSourceStream on: sources]].

	sourcesName _ FileDirectory localNameFor: fullSourcesName.
	"look for the sources file or an alias to it in the VM's directory"
	fd _ FileDirectory on: SmalltalkImage current vmPath.
	(fd fileExists: sourcesName)
		ifTrue: [sources _ fd readOnlyFileNamed: sourcesName].
	sources ifNotNil: [^ sources].
	"look for the sources file or an alias to it in the image directory"
	fd _ FileDirectory on: (FileDirectory dirPathFor: imageName).
	(fd fileExists: sourcesName)
		ifTrue: [sources _ fd readOnlyFileNamed: sourcesName].
	sources ifNotNil: [^ sources].
	"look for the sources in the current directory"
	fd _ DefaultDirectory.
	(fd fileExists: sourcesName)
		ifTrue: [sources _ fd readOnlyFileNamed: sourcesName].
	"sources may still be nil here"
	^sources
