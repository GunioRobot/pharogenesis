definitionOn: stream
	"Stream out messages to create this object."

	stream crtab; nextPutAll: 'created: '.
	created storeOn: stream.
	stream nextPut: $;; crtab; nextPutAll: 'updated:'.
	updated storeOn: stream.
	stream nextPut: $;; crtab; nextPutAll: 'name: '.
	name storeOn: stream.	
	stream nextPut: $;; crtab; nextPutAll: 'summary: '.
	summary storeOn: stream.
	stream nextPut: $;; crtab; nextPutAll: 'url: '.
	url storeOn: stream