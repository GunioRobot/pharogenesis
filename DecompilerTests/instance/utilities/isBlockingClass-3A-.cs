isBlockingClass: cls 
	"self new isBlockingClass: PNMReaderWriter"

	^ self blockingClasses includes: cls name asSymbol
