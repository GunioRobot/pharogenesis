contextStackMenu: aMenu shifted: shifted
	^ shifted ifFalse: [aMenu labels: 
'fullStack (f)
restart (r)
proceed (p)
step (t)
send (e)
where (w)
senders of...
implementors of...
method inheritance
versions
inst var refs...
inst var defs...
class var refs...
class variables
class refs
browse full
more...'
	lines: #(6 10 12 15)
	selections: #(fullStack restart proceed step send where
browseSendersOfMessages browseMessages methodHierarchy browseVersions
browseInstVarRefs browseInstVarDefs
browseClassVarRefs browseClassVariables browseClassRefs
browseMethodFull
shiftedYellowButtonActivity)]

	ifTrue: [aMenu labels: 
'browse class hierarchy
browse class
browse method
implementors of sent messages
change sets with this method
inspect instances
inspect subinstances
remove from current change set
more...' 
	lines: #(5 7 9)
	selections: #(classHierarchy browseClass 
		buildMessageBrowser browseAllMessages findMethodInChangeSets 
		inspectInstances inspectSubInstances
		removeFromCurrentChanges
		unshiftedYellowButtonActivity)]

