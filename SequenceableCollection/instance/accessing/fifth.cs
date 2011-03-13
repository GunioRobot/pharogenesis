fifth
	"Answer the fifth element of the receiver. Create an error notification if 
	the receiver contains fewer than four elements."
	^ self at: 5 ifAbsent: [self error: 'element not found']