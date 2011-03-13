urlAction: line reportOn: report 
 
	url :=  line readStream upTo: $' ; upTo: $'.
  	
	self reportSection: line on: report.

	(pageDataStream := self urlGet: self urlToDownload) 
		ifNil: [ self error: 'unable to contact host' ].
	 	
	self reportFor: line page: pageDataStream on: report 