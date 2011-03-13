messages: actuallyShown from: possible 
	self class includeStatusPane ifTrue: [
	self status: 'Showing ' , actuallyShown printString , ' of ' , possible printString , ' messages in "' , self category , '"']