declare: classThatIsARoot
	| existing |
	"The class just arrived in this segment.  How fit it into the Smalltalk dictionary?  If it had an association, that was installed with associationDeclareAt:."

	classThatIsARoot superclass name == #Player 
		ifTrue: [classThatIsARoot category: 'Morphic-UserObjects']
		ifFalse: [classThatIsARoot category: 'Morphic-Imported'].
	classThatIsARoot superclass addSubclass: classThatIsARoot.
	(Smalltalk includesKey: classThatIsARoot name) ifFalse: [
		"Class entry in Smalltalk not referred to in Segment, install anyway."
		^ Smalltalk at: classThatIsARoot name put: classThatIsARoot].
	existing _ Smalltalk at: classThatIsARoot name.
	existing xxxClass == ImageSegmentRootStub ifTrue: [
		"We are that segment!  Must ask it carefully!"
		^ Smalltalk at: classThatIsARoot name put: classThatIsARoot].
	existing == false | (existing == nil) ifTrue: [
		"association is in outPointers, just installed"
		^ Smalltalk at: classThatIsARoot name put: classThatIsARoot].
	"Conflict with existing global or copy of the class"
	(existing isKindOf: Class) ifTrue: [
		classThatIsARoot isSystemDefined not ifTrue: [
			"UniClass.  give it a new name"
			classThatIsARoot setName: Player chooseUniqueClassName.
			^ Smalltalk at: classThatIsARoot name put: classThatIsARoot].
		"Take the incoming one"
		self inform: 'Using newly arrived version of ', classThatIsARoot name.
		classThatIsARoot superclass removeSubclass: classThatIsARoot.	"just in case"
		(Smalltalk at: classThatIsARoot name) becomeForward: classThatIsARoot.
		^ classThatIsARoot superclass addSubclass: classThatIsARoot].
	self error: 'Name already in use by a non-class: ', classThatIsARoot name.
