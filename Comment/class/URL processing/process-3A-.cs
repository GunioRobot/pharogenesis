process: request 
	"URLs are of the form Comment.commentKey or 
	Comment.commentKey.note of Comment.commentKey.gif.
	
	If commentKey is accessed but not created, 
	create an empty one.
	If note is accessed, display it."
	| commentKey noteIndex newNote |
	commentKey _ request message at: 2.
	(CommentsTable includesKey: commentKey)
		ifFalse: 
			[CommentsTable at: commentKey put: Discussion new.
			(CommentsTable at: commentKey)
				title: commentKey.
			(CommentsTable at: commentKey)
				description: 'Discussion on ' , commentKey].
	request fields isNil
		ifFalse: 
			["Are there input fields?"
			newNote _ self createComment: request.
			newNote parent: commentKey.
			(CommentsTable at: commentKey)
				addNote: newNote.
			newNote url: ('Comment.',commentKey,'.',
				(CommentsTable at: commentKey) notes size printString)].
	request message size > 2
		ifTrue: 
			["There's a note reference or a request for a status image"
			noteIndex _ request message at: 3.
			noteIndex asUppercase = 'GIF'
			ifTrue: [
			request reply: (PWS success),(PWS content: 'image/gif').
			request reply: (HTMLformatter textToGIF: 
				(CommentsTable at: commentKey) status)]
			ifFalse: [request reply: (self showNote: ((CommentsTable at: commentKey)
						at: noteIndex asNumber))]]
		ifFalse: [request reply: (self showComment: (CommentsTable at: commentKey))]