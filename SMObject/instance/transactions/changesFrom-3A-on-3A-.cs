changesFrom: originalObject on: stream
	"Store messagesends that express the difference compared to
	the given original on the stream."

	stream crtab; nextPutAll: 'updated:'.
	updated storeOn: stream.
	originalObject name = name ifFalse:[
		stream nextPut: $;; crtab; nextPutAll: 'name: '.
		name storeOn: stream].
	originalObject summary = summary ifFalse:[
		stream nextPut: $;; crtab; nextPutAll: 'summary: '.
		summary storeOn: stream].
	originalObject url = url ifFalse:[
		stream nextPut: $;; crtab; nextPutAll: 'url: '.
		url storeOn: stream]