fileOutForm
	"Ask the user for a file name and then save the current source form 
	(form) under that name. Does not change the tool."

	| outName |
	outName _ self promptRequest: 'type a name for saving the source Form . . . '.
	FileDirectory convertName: outName with: [ :vol :name |
		(vol isLegalFileName: name)
			ifTrue: [(vol includesKey: name) 
					ifTrue: [(self confirm: 
									'Okay to write over old file?')
								ifTrue: [form writeOn: outName]]
					ifFalse: [form writeOn: outName]]].
	tool _ previousTool