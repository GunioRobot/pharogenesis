blockHome
	"If executing closure, search senders for method containing my closure method.  If not found return nil."

	| m |
	self isExecutingBlock ifFalse: [^ self].
	self sender ifNil: [^ nil].
	m _ self method.
	^ self sender findContextSuchThat: [:c | c method hasLiteralThorough: m]