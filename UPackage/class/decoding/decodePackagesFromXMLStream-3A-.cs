decodePackagesFromXMLStream: stream
	| doc |
	doc _ XMLDOMParser parseDocumentFrom: stream.
	^doc elements collect: [ :element | self decodeFromXMLElement: element ].
