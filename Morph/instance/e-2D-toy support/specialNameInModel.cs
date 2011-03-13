specialNameInModel
	"Return the name for this morph in the underlying model or nil."
	"Not an easy problem.  For now, take the first part of the mouseDownSelector symbol in my eventHandler (fillBrushMouseUp:morph: gives 'fillBrush').  5/26/97 tk"

	| hh |
	(self isKindOf: MorphicModel)
		ifTrue: [^ self slotName]
		ifFalse: [
			eventHandler ifNotNil: [
				eventHandler mouseDownSelector ifNotNil: [
					hh _ eventHandler mouseDownSelector indexOfSubCollection: 'Mouse' 
								startingAt: 1.
					hh > 0 ifTrue: [^ eventHandler mouseDownSelector copyFrom: 1 to: hh-1]].
				eventHandler mouseUpSelector ifNotNil: [
					hh _ eventHandler mouseUpSelector indexOfSubCollection: 'Mouse' 
								startingAt: 1.
					hh > 0 ifTrue: [^ eventHandler mouseUpSelector copyFrom: 1 to: hh-1]].
				]].

			"	(eventHandler mouseDownRecipient respondsTo: #nameFor:) ifTrue: [
					^ eventHandler mouseDownRecipient nameFor: self]]].	"
			"myModel _ self findA: MorphicModel.
			myModel ifNotNil: [^ myModel slotName]"
	
	^ self world specialNameInModelFor: self
