fileOutSelections 
	| f |
	f _ FileStream newFileNamed: (FillInTheBlank request: 'Enter file name' initialAnswer: 'Filename.st').
	listSelections with: changeList do: 
		[:selected :item | selected ifTrue: [item fileOutOn: f]].
	f close