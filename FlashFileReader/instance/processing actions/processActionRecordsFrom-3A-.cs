processActionRecordsFrom: data
	| code actionList action |
	actionList _ OrderedCollection new.
	[code _ data nextByte.
	code = 0] whileFalse:[
		code _ code bitAnd: 127. "Mask out the length-follow flag"
		log ifNotNil:[
			log cr; nextPutAll:'	Action #'; print: code.
			log nextPutAll:' ('; nextPutAll: (ActionTable at: code); nextPutAll:')'].
		action _ self dispatch: data on: code in: ActionTable 
					ifNone:[self processUnknownAction: data].
		action ifNotNil:[actionList add: action].
		log ifNotNil:[self flushLog].
	].
	^actionList