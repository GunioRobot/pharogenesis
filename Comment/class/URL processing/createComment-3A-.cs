createComment: request
	"Create a new comment from a Web request"
	| newNote newMap |
	request fields isNil ifTrue: [self error: 'No request to create a comment from!'].
	newNote := Note new.
	newMap := URLmap new.
	newNote author: (request fields at: 'author' ifAbsent: ['Anonymous']).
	newNote title: (request fields at: 'title' ifAbsent: ['Untitled']).
	newNote text: (HTMLformatter swikify: 
		(request fields at: 'text' ifAbsent: ['Nothing much to say'])
		linkhandler: [:phrase | newMap linkFor: phrase from: (request peerName) 
			storingTo: OrderedCollection new]).
	newNote timestamp: (Date today printString),' ',(Time now printString).
	newNote children: OrderedCollection new. "For later addition of threaded comments"
	^newNote
