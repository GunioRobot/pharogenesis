printOn: aStream 
	aStream nextPutAll: 'a MailDB on '.
	rootFilename ifNotNil: [aStream nextPutAll: '''' , rootFilename , '''']