fileOutSelections 
	| fileName internalStream |
	fileName _ FillInTheBlank request: 'Enter the base of file name' initialAnswer: 'Filename'.
	internalStream _ WriteStream on: (String new: 1000).
	internalStream header; timeStamp.
	listSelections with: changeList do: 
		[:selected :item | selected ifTrue: [item fileOutOn: internalStream]].

	FileStream writeSourceCodeFrom: internalStream baseName: fileName isSt: true useHtml: false.
