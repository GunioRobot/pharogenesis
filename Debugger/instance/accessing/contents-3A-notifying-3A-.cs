contents: aText notifying: aController 
	"The retrieved information has changed and its source must now be  
	updated. In this case, the retrieved information is the method of the  
	selected context."
	| selector classOfMethod category h ctxt newMethod |
	contextStackIndex = 0
		ifTrue: [^ false].
	self selectedContext isExecutingBlock
		ifTrue: [h := self selectedContext finalBlockHome.
			h
				ifNil: [self inform: 'Method not found for block, can''t edit'.
					^ false].
			(self confirm: 'I will have to revert to the method from
which this block originated.  Is that OK?')
				ifTrue: [self resetContext: h]
				ifFalse: [^ false]].

	classOfMethod := self selectedClass.
	category := self selectedMessageCategoryName.
	selector := self selectedClass parserClass new parseSelector: aText.
	selector == self selectedMessageName
		ifFalse: [self inform: 'can''t change selector'.
			^ false].
	selector := classOfMethod
				compile: aText
				classified: category
				notifying: aController.
	selector ifNil: [^ false]. "compile cancelled"
	contents := aText.
	newMethod := classOfMethod compiledMethodAt: selector.
	newMethod isQuick ifTrue: [ self down.
		self selectedContext jump: (self selectedContext previousPc - self selectedContext pc) ].
	ctxt := interruptedProcess popTo: self selectedContext.
	ctxt == self selectedContext ifFalse: [
		self inform: 'Method saved, but current context unchanged
because of unwind error. Click OK to see error'.
	] ifTrue: [ 
		newMethod isQuick ifFalse: [
			interruptedProcess
				restartTopWith: newMethod;
			 	stepToSendOrReturn ].
		contextVariablesInspector object: nil.
		theMethodNode := Preferences browseWithPrettyPrint
			ifTrue: [ctxt methodNodeFormattedAndDecorated: Preferences colorWhenPrettyPrinting]
			ifFalse: [ctxt methodNode].
		sourceMap := theMethodNode sourceMap.
		tempNames := theMethodNode tempNames.
	].
	self resetContext: ctxt.
	Smalltalk isMorphic ifTrue: [ World addAlarm: #changed: withArguments: #(contentsSelection) for: self at: (Time millisecondClockValue + 200) ].
	^ true
