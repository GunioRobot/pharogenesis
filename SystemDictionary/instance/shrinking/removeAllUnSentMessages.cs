removeAllUnSentMessages   "Smalltalk removeAllUnSentMessages" 
	"Remove all implementations of unsent messages."
	| sels n |
	sels _ self allUnSentMessages.

	"The following should be preserved for doIts, etc"
	#(dragon: hilberts: mandala: web test3 factorial benchmark benchFib
		newDepth: restoreAfter: forgetDoIts
		removeAllUnSentMessages abandonSources removeUnreferencedKeys
		reclaimDependents zapOrganization condenseChanges browseObsoleteReferences
		methodsFor:stamp: methodsFor:stamp:prior: instanceVariableNames:
		startTimerInterruptWatcher) do:
		[:sel | sels remove: sel ifAbsent: []].
	"The following may be sent by perform: in dispatchOnChar..."
	(ParagraphEditor classPool at: #CmdActions) asSet do:
		[:sel | sels remove: sel ifAbsent: []].
	(ParagraphEditor classPool at: #ShiftCmdActions) asSet do:
		[:sel | sels remove: sel ifAbsent: []].
	sels size = 0 ifTrue: [^ 0].

	n _ 0. Smalltalk allBehaviorsDo: [:x | n _ n+1].
	'Removing ', sels size printString , ' messages . . .'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: n
		during:
		[:bar |
		n _ 0.
		self allBehaviorsDo:
			[:class | bar value: (n _ n+1).
			sels do:
				[:sel | class removeSelectorSimply: sel]]].
	MethodDictionary allInstancesDo: [:d | d rehash].
	^ sels size