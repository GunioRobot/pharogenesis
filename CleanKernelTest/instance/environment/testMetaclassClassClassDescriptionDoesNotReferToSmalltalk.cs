testMetaclassClassClassDescriptionDoesNotReferToSmalltalk
	"self run: #testMetaclassClassClassDescriptionDoesNotReferToSmalltalk"

	self deny: ((Analyzer externalReferenceOf: (Array with: Metaclass)) includes: #Smalltalk).
	self deny: ((Analyzer externalReferenceOf: (Array with: ClassDescription)) includes: #Smalltalk). 
	self deny: ((Analyzer externalReferenceOf: (Array with: Class)) includes: #Smalltalk).