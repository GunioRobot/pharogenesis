methodInterfaceAt: aSelector ifAbsent: aBlock
	"Answer the vocabulary's method interface for the given selector; if absent, return the result of evaluating aBlock"

	^ methodInterfaces at: aSelector ifAbsent: [aBlock value]