scanTree: rootedPathName
	"FileDirectory scanTree: 'Reggae:Desktop Folder:New Mail'"

	| dirs files bytes todo p entries |
	dirs _ files _ bytes _ 0.
	todo _ OrderedCollection with: rootedPathName.
	[todo isEmpty] whileFalse: [
		p _ todo removeFirst.
		entries _ self directoryContentsFor: p.
		entries do: [ :entry |
			(entry at: 4) ifTrue: [
				todo addLast: (p, ':', (entry at: 1)).
				dirs _ dirs + 1.
			] ifFalse: [
				files _ files + 1.
				bytes _ bytes + (entry at: 5).
			].
		].
	].
	^ Array with: dirs with: files with: bytes
