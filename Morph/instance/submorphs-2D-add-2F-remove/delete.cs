delete
	"Remove the receiver as a submorph of its owner and make its new owner be nil."
	| aWorld |
	owner ifNotNil:
		[(extension == nil or: [self player == nil])
		ifTrue: [owner privateRemoveMorph: self.
				owner _ nil]
		ifFalse: ["Player must be notified"
				aWorld _ self world ifNil: [World].	"or some proper of getting the World"
				owner privateRemoveMorph: self.
				owner _ nil.
				self player noteDeletionOf: self fromWorld: aWorld]
		].