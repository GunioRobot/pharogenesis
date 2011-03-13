testDetectFileDo
	[(FileDirectory default forceNewFileNamed: 'filestream.tst') nextPutAll: '42';
		 close.
	FileStream
		detectFile: [FileDirectory default oldFileNamed: 'filestream.tst']
		do: [:file | 
			self assert: file notNil.
			self deny: file closed.
			self assert: file contentsOfEntireFile = '42']]
		ensure: [FileDirectory default deleteFileNamed: 'filestream.tst' ifAbsent: nil]