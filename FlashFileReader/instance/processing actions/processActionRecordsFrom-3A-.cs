processActionRecordsFrom: data
	| code actionList action |
	actionList := OrderedCollection new.
	[code := data nextByte.
	code = 0] whileFalse:[
		code := code bitAnd: 127. "Mask out the length-follow flag"
		log ifNotNil:[
			log cr; nextPutAll:'	Action #'; print: code.
			log nextPutAll:' ('; nextPutAll: (ActionTable at: code); nextPutAll:')'].
		action := self dispatch: data on: code in: ActionTable 
					ifNone:[self processUnknownAction: data].
		action ifNotNil:[actionList add: action].
		log ifNotNil:[self flushLog].
	].
	^actionList