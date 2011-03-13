sinsIn: aClass 
	| negativeDefined selfSent sins |
	negativeDefined := IdentitySet new.
	aClass selectorsAndMethodsDo: [:s :m | m isProvided ifFalse: [negativeDefined add: s]].
	selfSent := aClass sendCaches selfSenders ifNil: [^negativeDefined] ifNotNilDo: [:dict | dict keys].
	sins := negativeDefined union: (selfSent copyWithoutAll: aClass providedSelectors).
	^sins