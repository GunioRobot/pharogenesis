bug: aBugNo view: aFileName

	| file list |
	
	self setBug: aBugNo.
	
	file :=  self maStreamForFile: aFileName.

	list := self classChangeList new
			scanFile:  file from: 1 to: file size.
		 
	self classChangeList open: list name: (aFileName, ' mantis: ', aBugNo printString) 
		multiSelect: true.