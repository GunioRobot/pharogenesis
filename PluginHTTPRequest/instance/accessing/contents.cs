contents
	| |
	semaphore wait.
	(content isNil and:[fileStream notNil]) ifTrue:[
"		pos _ fileStream position."
		fileStream position: 0.
		content _ MIMEDocument content: fileStream upToEnd.
		(fileStream respondsTo: #close) ifTrue:[fileStream close].
	].
	^content