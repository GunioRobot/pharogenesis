hyperSqueakSupportClass
	"If present, answer the SqueakSupport class, else nil.  9/18/96 sw"
	| aClass |
	^ ((aClass _ self at: #SqueakSupport ifAbsent: [nil]) isKindOf: Class)
		ifTrue:
			[aClass]
		ifFalse:
			[nil]