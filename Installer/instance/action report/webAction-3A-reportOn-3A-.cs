webAction: line reportOn: report
	
	package :=  line readStream upTo: $' ; upTo: $'.

	self reportSection: line on: report.
	
 	url := self webFindUrlToDownload.
	
	self reportFor: line page: pageDataStream on: report 