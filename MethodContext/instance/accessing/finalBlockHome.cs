finalBlockHome
	"If executing closure, search senders for original method containing my closure method.  If not found return nil."

	| h |
	self isExecutingBlock ifFalse: [^ self].
	^ (h _ self blockHome) ifNotNil: [h finalBlockHome]