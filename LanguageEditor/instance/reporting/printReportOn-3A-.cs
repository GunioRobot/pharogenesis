printReportOn: aStream 
	"append to aStream a report of the receiver with swiki format"
	self printHeaderReportOn: aStream.
	self printUntranslatedReportOn: aStream.
	self printTranslationsReportOn: aStream