removeAllUnsentMessages
	"Smalltalk removeAllUnsentMessages"
	"[Smalltalk unusedClasses do: [:c | (Smalltalk at: c) removeFromSystem]. 
	Smalltalk removeAllUnSentMessages > 0] whileTrue."
	"Remove all implementations of unsent messages."
	| sels n |
	sels := self systemNavigation allUnSentMessages.
	"The following should be preserved for doIts, etc"
	"needed even after #majorShrink is pulled"
	#(#rehashWithoutBecome #compactSymbolTable #rebuildAllProjects #browseAllSelect:  #lastRemoval #scrollBarValue: vScrollBarValue: #scrollBarMenuButtonPressed: #withSelectionFrom: #to: #removeClassNamed: #dragon: #hilberts: #mandala: #web #factorial #tinyBenchmarks #benchFib #newDepth: #restoreAfter: #forgetDoIts #zapAllMethods #obsoleteClasses #removeAllUnSentMessages #abandonSources #removeUnreferencedKeys #reclaimDependents #zapOrganization #condenseChanges #browseObsoleteReferences #subclass:instanceVariableNames:classVariableNames:poolDictionaries:category: #methodsFor:stamp: #methodsFor:stamp:prior: #instanceVariableNames: #startTimerInterruptWatcher #unusedClasses )
		do: [:sel | sels
				remove: sel
				ifAbsent: []].
	"The following may be sent by perform: in dispatchOnChar..."
	(ParagraphEditor classPool at: #CmdActions) asSet
		do: [:sel | sels
				remove: sel
				ifAbsent: []].
	(ParagraphEditor classPool at: #ShiftCmdActions) asSet
		do: [:sel | sels
				remove: sel
				ifAbsent: []].
	sels size = 0
		ifTrue: [^ 0].
	n := 0.
	self systemNavigation
		allBehaviorsDo: [:x | n := n + 1].
	'Removing ' , sels size printString , ' messages . . .'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: n
		during: [:bar | 
			n := 0.
			self systemNavigation
				allBehaviorsDo: [:class | 
					bar value: (n := n + 1).
					sels
						do: [:sel | class basicRemoveSelector: sel]]].
	^ sels size