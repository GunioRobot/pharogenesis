contents: aString notifying: aController
	"Compile the code in aString and notify aController of any errors. If there are no errors, then automatically proceed."

	(class compile: aString classified: category notifying: aController)
		ifNil: [^ false]
		ifNotNil: [self proceed].
