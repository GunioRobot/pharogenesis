presumedSentMessages   | sent |
"Smalltalk presumedSentMessages"

	"The following should be preserved for doIts, etc"
	sent := IdentitySet new.
	#( rehashWithoutBecome compactSymbolTable rebuildAllProjects
		browseAllSelect:  lastRemoval
		scrollBarValue: vScrollBarValue: scrollBarMenuButtonPressed: 
		withSelectionFrom:  to: removeClassNamed:
		dragon: hilberts: mandala: web factorial tinyBenchmarks benchFib
		newDepth: restoreAfter: forgetDoIts zapAllMethods obsoleteClasses
		removeAllUnsentMessages abandonSources removeUnreferencedKeys
		reclaimDependents zapOrganization condenseChanges browseObsoleteReferences
		subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:
		methodsFor:stamp: methodsFor:stamp:prior: instanceVariableNames:
		startTimerInterruptWatcher unusedClasses) do:
		[:sel | sent add: sel].
	"The following may be sent by perform: in dispatchOnChar..."
	(ParagraphEditor classPool at: #CmdActions) asSet do:
		[:sel | sent add: sel].
	(ParagraphEditor classPool at: #ShiftCmdActions) asSet do:
		[:sel | sent add: sel].
	^ sent