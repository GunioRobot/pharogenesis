classToUseFromInstance: anInstance ofClass: aClass
	"A small convenience to assist in complications arising because an instance is sometimes provided and sometimes not"

	^ anInstance ifNotNil: [anInstance class] ifNil: [aClass]
