enter
	"Enter my project."
	project class == DiskProxy ifTrue: ["When target is not in yet"
		project enter: false revert: false saveForRevert: false.	"will bring it in"
		project class == DiskProxy ifTrue: [self error: 'Could not find view']].
	(owner isKindOf: SystemWindow)
		ifTrue: [project setViewSize: self extent].
	self showBorderAs: Color gray.
	project enter: false revert: false saveForRevert: false.
