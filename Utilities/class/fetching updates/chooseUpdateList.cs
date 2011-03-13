chooseUpdateList
	"When there is more than one set of update servers, let the user choose which we will update from.  Put it at the front of the list."

	| index him |
	UpdateUrlLists size > 1 ifTrue: [
		index _ (PopUpMenu labelArray: (UpdateUrlLists collect: [:each | each first]) lines: #()) 
			startUpWithCaption: 'Choose a group of servers
from which to fetch updates.'.
		index > 0 ifTrue: [
			him _ UpdateUrlLists at: index.
			UpdateUrlLists removeAt: index.
			UpdateUrlLists addFirst: him]].
