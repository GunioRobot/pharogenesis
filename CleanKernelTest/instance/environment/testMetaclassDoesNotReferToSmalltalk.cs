testMetaclassDoesNotReferToSmalltalk
	"self run: #testMetaclassDoesNotReferToSmalltalk"

	self deny: ((Analyzer externalReferenceOf: (Array with: Metaclass)) includes: #Smalltalk).