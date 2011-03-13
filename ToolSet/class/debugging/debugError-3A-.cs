debugError: anError
	"Handle an otherwise unhandled error"
	self default ifNil:[ | ctx |
		Smalltalk 
			logError: anError description 
			inContext: (ctx := anError signalerContext)
			to: 'SqueakDebug.log'.
		self inform: (anError description, String cr, ctx shortStack).
		^anError return].
	^self default debugError: anError