serve: aSocket
	"Respond to a request arriving on the given socket and return a string to be entered in the log file."

    | inst reportMsg |
     inst _ self new.
     [inst initializeFrom: aSocket.
     inst getReply]
         ifError: [:msg :rec |  "Fix by Mark Schwenk to deal with Exceptions"
	    reportMsg _ (msg size >= 8 and: [(msg copyFrom: 1 to: 7) = 'Error: '])
                ifTrue: [msg copyFrom: 8 to: msg size]
                ifFalse: [msg].
            inst report: reportMsg for: rec].            
     aSocket closeAndDestroy: 30.
     ^ inst log contents

