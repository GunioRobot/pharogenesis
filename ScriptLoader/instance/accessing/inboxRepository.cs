inboxRepository
	repository isNil 
		ifTrue: [ repository := 
					MCHttpRepository
						location: 'http://source.squeakfoundation.org/inbox'
						user: ''
						password: ''].
	^ repository