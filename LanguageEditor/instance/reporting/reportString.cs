reportString
	"answer a string with a report of the receiver"
	| stream |
	stream := String new writeStream.
	self printReportOn: stream.
	^ stream contents