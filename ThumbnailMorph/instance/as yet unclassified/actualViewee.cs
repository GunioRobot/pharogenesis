actualViewee
	"Return the actual morph to be viewed, or nil if there isn't an appropriate morph to view."

	| aMorph actualViewee |
	aMorph _ self morphToView ifNil: [^ nil]. 
	aMorph isInWorld ifFalse: [^ nil].
	actualViewee _ viewSelector ifNil: [aMorph] ifNotNil: [objectToView perform: viewSelector].
	actualViewee == 0 ifTrue: [^ nil].  "valueAtCursor result for an empty HolderMorph"
	actualViewee ifNil: [actualViewee _ objectToView].
	actualViewee isMorph ifFalse: [actualViewee _ actualViewee costume].
	(actualViewee isMorph and: 
		[actualViewee isFlexMorph and: [actualViewee submorphs size = 1]])
			ifTrue: [actualViewee _ actualViewee firstSubmorph].
	^ actualViewee