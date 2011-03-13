shiftedMessageMenu: aMenu

	^ aMenu labels: 'browse class hierarchy
browse class
browse method
implementors of sent messages
change sets with this method
inspect instances
inspect subinstances
more...' 
	lines: #(5 7 10)
	selections: #(classHierarchy browseClass 
		buildMessageBrowser browseAllMessages findMethodInChangeSets 
		inspectInstances inspectSubInstances
		unshiftedYellowButtonActivity)