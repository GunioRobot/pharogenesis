fileInMonticelloPackageNamed: memberName 
	"This is to be used from preamble/postscript code to file in zip 
	members as Monticello packages (.mc)."

	| member file mcPackagePanel mcRevisionInfo mcSnapshot mcFilePackageManager mcPackage info snapshot newCS mcBootstrap |

	mcPackagePanel _ Smalltalk at: #MCPackagePanel ifAbsent: [ ].
	mcRevisionInfo _ Smalltalk at: #MCRevisionInfo ifAbsent: [ ].
	mcSnapshot _ Smalltalk at: #MCSnapshot ifAbsent: [ ].
	mcFilePackageManager _ Smalltalk at: #MCFilePackageManager ifAbsent: [ ].
	mcPackage _ Smalltalk at: #MCPackage ifAbsent: [ ].
	member _ self memberNamed: memberName.
	member ifNil: [ ^self errorNoSuchMember: memberName ].

	"We are missing MCInstaller, Monticello and/or MonticelloCVS.
	If the bootstrap is present, use it. Otherwise interact with the user."
	({ mcPackagePanel. mcRevisionInfo. mcSnapshot. mcFilePackageManager. mcPackage } includes: nil)
		ifTrue: [
			mcBootstrap := self getMCBootstrapLoaderClass.
			mcBootstrap ifNotNil: [ ^self fileInMCVersion: member withBootstrap: mcBootstrap ].

			(self confirm: ('Monticello support is not installed, but must be to load member named ', memberName, '.
Load it from SqueakMap?'))
				ifTrue: [ self class loadMonticello; loadMonticelloCVS.
					^self fileInMonticelloPackageNamed: memberName ]
				ifFalse: [ ^false ] ].

	member extractToFileNamed: member localFileName inDirectory: self directory.
	file _ (Smalltalk at: #MCFile)
				name: member localFileName
				directory: self directory.

	self class withCurrentChangeSetNamed: file name do: [ :cs |
		newCS _ cs.
		file readStreamDo: [ :stream |
			info _ mcRevisionInfo readFrom: stream nextChunk.
			snapshot _ mcSnapshot fromStream: stream ].
			snapshot install.
			(mcFilePackageManager forPackage:
				(mcPackage named: info packageName))
					file: file
		].

	newCS isEmpty ifTrue: [ ChangeSorter removeChangeSet: newCS ].

	mcPackagePanel allSubInstancesDo: [ :ea | ea refresh ].
	World doOneCycle.

	self installed: member.
