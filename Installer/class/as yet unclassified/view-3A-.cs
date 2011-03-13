view: webPageNameOrUrl

| theReport |

theReport := String streamContents: [ :report | 
	(webPageNameOrUrl beginsWith: 'http://') ifTrue: [ 
		self new urlAction: ('Installer installUrl: ', (webPageNameOrUrl printString),'.')  	
						 reportOn: report.
	]
	ifFalse: [
		self new webAction: ('Installer install: ', (webPageNameOrUrl printString),'.')  	
						 reportOn: report.
	].
].

Workspace new contents: (theReport contents); openLabel: webPageNameOrUrl.

^theReport contents
