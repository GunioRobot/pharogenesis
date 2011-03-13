messageListMenu: aMenu shifted: shifted
	^ shifted ifFalse: [aMenu labels:
'browse full
fileOut
printOut
senders of...
implementors of...
method inheritance
versions
inst var refs...
inst var defs...
class var refs...
class variables
class refs
remove
more...'
	lines: #(3 7 12)
	selections:
		#(browseMethodFull fileOutMessage printOutMessage
		browseSendersOfMessages browseMessages methodHierarchy browseVersions
		browseInstVarRefs browseInstVarDefs browseClassVarRefs 
			browseClassVariables browseClassRefs
		removeMessage shiftedYellowButtonActivity )]

	ifTrue: [aMenu labels: 'browse class hierarchy
browse class
browse method
implementors of sent messages
change sets with this method
inspect instances
inspect subinstances
remove from this browser
revert to previous version
remove from current change set
revert and forget
more...' 
	lines: #(5 7 11)
	selections: #(classHierarchy browseClass 
		buildMessageBrowser browseAllMessages findMethodInChangeSets 
		inspectInstances inspectSubInstances
		removeMessageFromBrowser revertToPreviousVersion 
		removeFromCurrentChanges revertAndForget
		unshiftedYellowButtonActivity)]
