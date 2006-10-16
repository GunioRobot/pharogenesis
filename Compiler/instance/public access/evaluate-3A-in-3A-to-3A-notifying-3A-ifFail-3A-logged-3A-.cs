evaluate: textOrStream in: aContext to: receiver notifying: aRequestor ifFail: failBlock logged: logFlag
	"Compiles the sourceStream into a parse tree, then generates code into a method. In other words, if receiver is not nil, then the text can refer to instance variables of that receiver (the Inspector uses this). If aContext is not nil, the text can refer to temporaries in that context (the Debugger uses this). If aRequestor is not nil, then it will receive a notify:at: message before the attempt to evaluate is aborted. Finally, the compiled method is directly invoked without modifying the receiving-class."

	| methodNode method value toLog itsSelectionString itsSelection |
	class := (aContext isNil 
		ifTrue: [ receiver ] 
		ifFalse: [ aContext receiver ])
			class.
	self from: textOrStream class: class context: aContext notifying: aRequestor.
	methodNode := self 
		translate: sourceStream
		noPattern: true 
		ifFail: [ ^ failBlock value ].
	method := methodNode generate.
	method selector ifNil: [method selector: #DoIt].
	self interactive
		ifTrue: [ method := method copyWithTempNames: methodNode tempNames ].
	value := receiver 
		withArgs: (context isNil
			ifTrue: [ #() ]
			ifFalse: [ Array with: aContext ])
		executeMethod: method.
	logFlag ifTrue:
		[toLog := ((requestor respondsTo: #selection)  and:
			[(itsSelection := requestor selection) notNil] and:
			[(itsSelectionString := itsSelection asString) isEmptyOrNil not] )
			ifTrue: 
				[itsSelectionString]
			ifFalse:
				[sourceStream contents].
		SystemChangeNotifier uniqueInstance evaluated: toLog context: aContext ].
	^ value.