doDup: evt with: dupHandle
	"Ask hand to duplicate my target."
	evt hand obtainHalo: self.
	(target isKindOf: SelectionMorph) ifTrue:
		[^ target doDup: evt fromHalo: self handle: dupHandle].
	self setTarget: (target duplicateMorph: evt).
	self removeAllHandlesBut: dupHandle.
	self step. "update position if necessary"
	evt hand addMouseListener: self. "Listen for the drop"