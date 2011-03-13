repository
	repository isNil  
		ifTrue: [ repository := 
					MCHttpRepository
						location:  'http://source.squeakfoundation.org/39a'
						user: ''
						password: ''].
	^ repository