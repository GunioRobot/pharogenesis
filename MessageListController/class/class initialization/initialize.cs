initialize
	"Initialize the yellow button menu for message lists.  2/1/96 sw
	 7/30/96 sw: added browseInstVarDefs"

	MessageListYellowButtonMenu _ 
		PopUpMenu 
			labels:
'browse class
fileOut
senders
implementors
senders of...
implementors of...
versions
inst var refs...
inst var defs...
class var refs...
class variables
class refs
remove
more...'
			lines: #(2 6 7 9 12).
	MessageListYellowButtonMessages _
		#( browseClass  fileOut
		senders implementors  browseSendersOfMessages messages
		versions browseInstVarRefs browseInstVarDefs classVarRefs browseClassVariables browseClassRefs remove 
		shiftedYellowButtonActivity )
"
	MessageListController initialize.
	MessageListController allInstancesDo:
		[:x | x initializeYellowButtonMenu].
"