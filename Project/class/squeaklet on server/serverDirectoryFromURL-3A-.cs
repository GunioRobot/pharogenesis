serverDirectoryFromURL: aURLString

	| dir |
	self flag: #bob.		"need to include swikis in this - hacked for now"

	(aURLString findString: '/SuperSwikiProj/') > 0 ifTrue: [
		dir _ SuperSwikiServer new fullPath: (aURLString copyUpToLast: $/).
		^dir
	].

	^ServerDirectory new fullPath: aURLString