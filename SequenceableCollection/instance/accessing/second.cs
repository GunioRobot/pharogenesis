second
	"Answer the second element of the receiver. Create an error notification if 
	the receiver contains fewer than two elements."
	^ self at: 2 ifAbsent: [self error: 'element not found']