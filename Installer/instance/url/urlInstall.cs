urlInstall 
"
Installer installUrl: 'wiki.squeak.org/742'.
"
 
	self logCR: 'retrieving ', self urlToDownload , ' ...'.
	
	(pageDataStream := self urlGet: self urlToDownload) 
		ifNil: [ self error: 'unable to contact host' ].
	 
	self install: self urlToDownload from: pageDataStream.
	
	^ pageDataStream 
