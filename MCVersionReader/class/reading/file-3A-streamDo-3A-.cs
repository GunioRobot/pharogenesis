file: fileName streamDo: aBlock
	| file |
	^ 	[file := FileStream readOnlyFileNamed: fileName.
		aBlock value: file]
			ensure: [file close]