initializeMessageListMenu
	"ChangeSorter initializeMessageListMenu"

	MsgListMenu _ PopUpMenu labels: 
'copy method to other side
delete method from change set
remove method from system
browse full
fileOut
printOut
senders
implementors
senders of...
implementors of...
versions
more...'
			lines: #(1 3 6 11).

	MsgListSelectors _ 
	#(copyToOther forget removeMessage browseFull fileOut printOut
		senders implementors  browseSendersOfMessages messages versions
		shiftedYellowButtonActivity)