evaluate: textOrStream in: aContext to: receiver notifying: aRequestor ifFail: failBlock logged: logFlag
	"Compiles the sourceStream into a parse tree, then generates code into a 
	method. This method is then installed in the receiver's class so that it 
	can be invoked. In other words, if receiver is not nil, then the text can 
	refer to instance variables of that receiver (the Inspector uses this). If 
	aContext is not nil, the text can refer to temporaries in that context (the 
	Debugger uses this). If aRequestor is not nil, then it will receive a 
	notify:at: message before the attempt to evaluate is aborted. Finally, the 
	compiled method is invoked from here as DoIt or (in the case of 
	evaluation in aContext) DoItIn:. The method is subsequently removed 
	from the class, but this will not get done if the invocation causes an 
	error which is terminated. Such garbage can be removed by executing: 
	Smalltalk allBehaviorsDo: [:cl | cl removeSelector: #DoIt; removeSelector: 
	#DoItIn:]."

	| methodNode method value selector |
	class _ (aContext == nil ifTrue: [receiver] ifFalse: [aContext receiver]) class.
	self from: textOrStream class: class context: aContext notifying: aRequestor.
	methodNode _ self translate: sourceStream noPattern: true ifFail:
		[^failBlock value].
	method _ methodNode generate: #(0 0 0 0).
	self interactive ifTrue:
		[method _ method copyWithTempNames: methodNode tempNames].
	
	selector _ context isNil
		ifTrue: [#DoIt]
		ifFalse: [#DoItIn:].
	class addSelectorSilently: selector withMethod: method.
	value _ context isNil
		ifTrue: [receiver DoIt]
		ifFalse: [receiver DoItIn: context].
	InMidstOfFileinNotification signal 
		ifFalse: [class basicRemoveSelector: selector].
	logFlag ifTrue: [SystemChangeNotifier uniqueInstance evaluated: sourceStream contents context: aContext].
	^ value.