messagesDo: aBlock
	"perform aBlock on each message text"
	| thisMessage |

	1 to: self numMessages do: [ :num |
		thisMessage _ self retrieveMessage: num.
		aBlock value: thisMessage.
	].
	
