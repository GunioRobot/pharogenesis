methodInterfaceForSelector: aSelector class: aClass
	"Answer a method interface for the selector"

	^ self methodInterfaceAt: aSelector ifAbsent:
		[MethodInterface new conjuredUpFor: aSelector class: aClass]