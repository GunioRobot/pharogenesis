endXMLOn: stream
	"Stream out endTag for this object."

	stream nextPutAll: '</', self startTag, '>'