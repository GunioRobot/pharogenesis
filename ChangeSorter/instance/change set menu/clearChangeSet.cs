clearChangeSet
	"Clear out the current change set, after getting a confirmation.  "

	| message |

	myChangeSet isEmpty ifFalse:
		[message _ 'Are you certain that you want to 
forget all the changes in this set?'.
		(self confirm: message) ifFalse: [^ self]].
	myChangeSet clear.
	self launch