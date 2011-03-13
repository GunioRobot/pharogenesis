webInstall 
"
Installer install: 'MyPage'.
"
 	url := self webFindUrlToDownload ifNil: [ self logCR: 'url not found'. self error: 'url not found' ].
	
	self logCR: 'found ',  url, ' ...'.
	
	pageDataStream size > 0 
		ifTrue: [ self install: url from: pageDataStream ]
		ifFalse: [ self logCR: '...',url,' was empty' ].
	
	^ pageDataStream.

	