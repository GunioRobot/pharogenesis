startXMLOn: stream
	"Stream out startTag to create this object."

	stream nextPutAll: '<?xml version="1.0" encoding="UTF-8"?>';cr.
	stream nextPutAll: '<', self startTag, ' created="'.
	created storeOn: stream.
	stream nextPutAll: '" updated="'.
	updated storeOn: stream.
	stream nextPutAll: '" name="'.
	name storeOn: stream.
	stream nextPutAll: '" summary="'.
	summary storeOn: stream.
	stream nextPutAll: '" url="'.
	url storeOn: stream.
	stream nextPutAll: '">';cr