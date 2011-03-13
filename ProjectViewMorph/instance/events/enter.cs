enter
	"Enter my project."
	self world == self outermostWorldMorph ifFalse: [^1 beep]. "can't do this at the moment"
	project class == DiskProxy ifFalse: [
		(project world notNil and: [project world isMorph and:
				[project world outermostWorldMorph == self outermostWorldMorph]]) ifTrue: [
			^1 beep		"project is open in a window already"
		].
	].

	project class == DiskProxy ifTrue: ["When target is not in yet"
		self enterWhenNotPresent.	"will bring it in"
		project class == DiskProxy ifTrue: [^self inform: 'Project not found']].
	(owner isKindOf: SystemWindow)
		ifTrue: [project setViewSize: self extent].
	self showMouseState: 3.
	project enter: false revert: false saveForRevert: false.
