installAsActiveSubprojectIn: enclosingWorld titled: aString

	| opt newWidth |

	opt _ self optimumExtentFromAuthor.
	(opt x > (enclosingWorld width * 0.7) or: 
			[opt y > (enclosingWorld height * 0.7)]) ifTrue: [
		newWidth _ enclosingWorld width // 2.
		opt _ newWidth @ (opt y * newWidth / opt x) truncated
	].
	^self 
		installAsActiveSubprojectIn: enclosingWorld 
		at: (enclosingWorld topLeft + (enclosingWorld extent - opt // 2) extent: opt) 
		titled: aString
