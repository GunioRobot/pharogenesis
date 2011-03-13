inputFrom: request
        "Take user's input and respond with a searchresult or store the edit"

        | coreRef page |
        coreRef _ request message size < 2
                ifTrue: ['1']
                ifFalse: [request message at: 2].
        coreRef = 'searchresult' ifTrue: [
                "If contains search string, do search"
                request reply: PWS crlf, 
                        ((self formatterFor: 'recent') format:
                                (urlmap searchFor: (request fields at: 'searchFor' ifAbsent: ['nothing']))).
                ^ #return].
        (request fields includesKey: 'text') ifTrue: ["It's a response from an edit, so store the page"
                page _ urlmap
                        storeID: coreRef
                        text: (request fields at: 'text' ifAbsent: ['blank text'])
                        from: request peerName.
                page user: request userID.  "Address is machine, user only if logged in"
                ^ self].        "return self means do serve the edited page afterwards"
        "oops, a new kind!"
        Transcript show: 'Unknown data from client. '; show: request fields printString; cr.