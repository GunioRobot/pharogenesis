messageListMenu: aMenu shifted: shifted
	| aList |
	aList _ shifted
		ifFalse: [#(
			('browse full (b)' 						browseMethodFull)
			('browse hierarchy (h)'					classHierarchy)
			('browse method (O)'					openSingleMessageBrowser)
			-
			('fileOut'								fileOutMessage)
			('printOut'								printOutMessage)
			-
			('senders of... (n)'						browseSendersOfMessages)
			('implementors of... (m)'					browseMessages)
			('inheritance (i)'						methodHierarchy)
			('versions (v)'							browseVersions)
			-
			('inst var refs...'						browseInstVarRefs)
			('inst var defs...'						browseInstVarDefs)
			('class var refs...'						browseClassVarRefs)
			('class variables'						browseClassVariables)
			('class refs (N)'							browseClassRefs)
			-
			('remove method (x)'					removeMessage)
			-
			('more...'								shiftedYellowButtonActivity))]
		ifTrue: [#(
			('method pane' 							makeIsolatedCodePane)
			"('make a scriptor'						makeScriptor)"
			('toggle diffing'							toggleDiffing)
			('implementors of sent messages'			browseAllMessages)
			-
			('sample instance'						makeSampleInstance)
			('inspect instances'						inspectInstances)
			('inspect subinstances'					inspectSubInstances)
			-
			('remove from this browser'				removeMessageFromBrowser)
			('change category...'					changeCategory)
			-
			('change sets with this method'			findMethodInChangeSets)
			('revert to previous version'				revertToPreviousVersion)
			('remove from current change set'		removeFromCurrentChanges)
			('revert and forget'						revertAndForget)
			-
			('fetch documentation'					fetchDocPane)
			('more...' 								unshiftedYellowButtonActivity))].
	^ aMenu addList: aList
