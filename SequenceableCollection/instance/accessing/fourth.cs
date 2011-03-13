fourth
	"Answer the fourth element of the receiver. Create an error notification if 
	the receiver contains fewer than four elements."
	^ self at: 4 ifAbsent: [self error: 'element not found']