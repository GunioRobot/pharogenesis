messageMenu: aMenu shifted: shifted
	"Could be for a single or double changeSorter"
	shifted ifTrue: [^ self shiftedMessageMenu: aMenu].
	parent ifNotNil: [
		^ aMenu labels: 
'copy method to other side
delete method from change set
remove method from system
browse full
fileOut
printOut
senders of...
implementors of...
versions
more...'
		lines: #(1 3 6 9 )
		selections: #(copyMethodToOther forget removeMessage browseMethodFull fileOutMessage printOutMessage browseSendersOfMessages browseMessages browseVersions shiftedYellowButtonActivity )]

	ifNil: [^ aMenu labels: 
'delete method from change set
remove method from system
browse full
fileOut
printOut
senders of...
implementors of...
versions
more...'
		lines: #(2 5 8 )
		selections: #( forget removeMessage browseMethodFull fileOutMessage printOutMessage browseSendersOfMessages browseMessages browseVersions shiftedYellowButtonActivity )]
