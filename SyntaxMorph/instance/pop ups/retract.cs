retract
	"replace this message with its receiver.  I am the message node."
	| rec cascade msg |
	(self nodeClassIs: CascadeNode) ifTrue:
		["This is a piece of a cascaded message -- just delete it"
		self deletePopup.
		cascade _ owner.
		self delete.
		cascade setSelection: {cascade. nil. cascade}.
		^ cascade acceptIfInScriptor].
	self deletePopup.
	(rec _ self receiverNode)
		ifNil: [msg _ owner.
			rec _ owner receiverNode.
			msg owner replaceSubmorph: msg by: rec]
		ifNotNil: [owner replaceSubmorph: self by: rec].
	rec setSelection: {rec. nil. rec}.
	rec acceptIfInScriptor.