fileReaderServicesForFile: fullName suffix: suffix 

	|  services |
	services _ OrderedCollection new.
	services add: self serviceAddToNewZip.
	({'zip'.'sar'.'pr'. 'mcz'. '*'} includes: suffix)
		ifTrue: [services add: self serviceOpenInZipViewer.
				services add: self serviceExtractAll].
	^ services