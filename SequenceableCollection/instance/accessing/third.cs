third
	"Answer the third element of the receiver. Create an error notification if 
	the receiver contains fewer than three elements."

	^ self at: 3 ifAbsent: [self error: 'element not found']