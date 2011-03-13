testOldFileOrNoneNamed

	| file |
	file := self myAssuredDirectory oldFileOrNoneNamed: 'test.txt'.
	[self assert: file isNil.
	
	"Reproduction of Mantis #1049"
	(self myAssuredDirectory fileNamed: 'test.txt')
		nextPutAll: 'foo';
		close.
		
	file := self myAssuredDirectory oldFileOrNoneNamed: 'test.txt'.
	self assert: file notNil]
		ensure: [
			file ifNotNil: [file close].
			self myAssuredDirectory deleteFileNamed: 'test.txt' ifAbsent: nil]
	
