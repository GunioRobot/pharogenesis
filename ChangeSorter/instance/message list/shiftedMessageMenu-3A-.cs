shiftedMessageMenu: aMenu
	^ aMenu addList: #(
		-
		('method pane'						makeIsolatedCodePane)
		('toggle diffing'						toggleDiffing)
		('implementors of sent messages'		browseAllMessages)
		('change category...'				changeCategory)
			-
		('sample instance'					makeSampleInstance)
		('inspect instances'					inspectInstances)
		('inspect subinstances'				inspectSubInstances)
		-
		('change sets with this method'		findMethodInChangeSets)
		('revert to previous version'			revertToPreviousVersion)
		('revert and forget'					revertAndForget)
		-
		('more...'							unshiftedYellowButtonActivity))