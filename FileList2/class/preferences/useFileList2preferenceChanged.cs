useFileList2preferenceChanged
	| preferred quads registered |
	preferred := Preferences useFileList2
				ifTrue: [#FileList2]
				ifFalse: [#FileList].
	quads := Flaps registeredFlapsQuads
				at: 'Tools'
				ifAbsent: [^ self].
	registered := quads
				detect: [:quad | quad first  beginsWith: 'FileList']
				ifNone: [Flaps registerQuad: {
					preferred. 
					#prototypicalToolWindow.
					'File List'.
					'A File List is a tool for browsing folders and files on disks and FTP servers.'} 						forFlapNamed: 'Tools'.
					nil].
	registered
		ifNotNil: [registered at: 1 put: preferred].
	Flaps replaceToolsFlap