readFromDisk: evt
	| menu |
	menu _ MenuMorph new.
	(FileDirectory default fileNamesMatching: '*.fmp') do:
		[:fileName |
		menu add: fileName
			target: self selector: #readFileNamed:
			argument: fileName].
	menu popUpAt: evt hand position event: evt.
