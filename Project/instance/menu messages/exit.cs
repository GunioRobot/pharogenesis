exit
	"Leave the current project and return to the project in which this one was created."

	self isTopProject ifTrue: [^ PopUpMenu notify: 'Can''t exit the top project'].
	parentProject enter: false revert: false saveForRevert: false.
