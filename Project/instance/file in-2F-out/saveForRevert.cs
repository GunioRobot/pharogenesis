saveForRevert
	| |
	"Exit to the parent project.  Do a GC.  Save the project in a segment.  Record the ImageSegment object as the revertToMe in Project parameters"

	self isTopProject ifTrue: [^ PopUpMenu notify: 'Can''t exit the top project'].
	parentProject enter: false revert: false saveForRevert: true.
	"does not return!"

