toReturnSelf
	"Answer an instance of me that is a quick return of the instance (^self)."

	^ self toReturnSelfTrailerBytes: #(0 0 0 0)