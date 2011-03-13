retract
	"replace this message with its receiver.  I am the message node."
	| rec cascade |
	self isCascadePart ifTrue:
		["This is a piece of a cascaded message -- just delete it"
		self deletePopup.
		cascade _ owner.
		self delete.
		cascade setSelection: {cascade. nil. cascade}.
		^ cascade acceptIfInScriptor].
	rec _ submorphs detect: [:m | m isSyntaxMorph and: [m parseNode == parseNode receiver]].
	self deletePopup.
	owner replaceSubmorph: self by: rec.
	rec setSelection: {rec. nil. rec}.
	rec acceptIfInScriptor.