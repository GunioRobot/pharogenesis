contextStackMenu: aMenu shifted: shifted
	"Set up the menu appropriately for the context-stack-list, either shifted or unshifted as per the parameter provided"

	^ shifted ifFalse: [aMenu labels: 
'fullStack (f)
restart (r)
proceed (p)
step (t)
send (e)
where (w)
peel to first like this
senders of... (n)
implementors of... (m)
inheritance (i)
versions (v)
inst var refs...
inst var defs...
class var refs...
class variables
class refs (N)
browse full (b)
file out 
mail out bug report
more...'
	lines: #(7 11 13 16 19)
	selections: #(fullStack restart proceed doStep send where peelToFirst
browseSendersOfMessages browseMessages methodHierarchy browseVersions
browseInstVarRefs browseInstVarDefs
browseClassVarRefs browseClassVariables browseClassRefs
browseMethodFull fileOutMessage mailOutBugReport
shiftedYellowButtonActivity)]

	ifTrue: [aMenu labels: 
'browse class hierarchy
browse class
browse method (O)
implementors of sent messages
change sets with this method
inspect instances
inspect subinstances
revert to previous version
remove from current change set
revert & remove from changes
more...' 
	lines: #(5 7 10)
	selections: #(classHierarchy browseClass 
		openSingleMessageBrowser browseAllMessages findMethodInChangeSets 
		inspectInstances inspectSubInstances
		revertToPreviousVersion 
		removeFromCurrentChanges revertAndForget
		unshiftedYellowButtonActivity)]

