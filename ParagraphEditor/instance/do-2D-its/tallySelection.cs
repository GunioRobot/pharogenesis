tallySelection
	"Treat the current selection as an expression; evaluate and tally it."
	| v receiver context compiledMethod |

	(model respondsTo: #doItReceiver) 
		ifTrue: 
			[FakeClassPool adopt: model selectedClass. "Include model pool vars if any"
			receiver := model doItReceiver.
			context := model doItContext]
		ifFalse:
			[receiver := context := nil].
	self lineSelectAndEmptyCheck: [ ^ self ].

	[
		compiledMethod := self compileSelectionFor: receiver in: context.
		compiledMethod ifNil: [^ self].
		MessageTally spyOn: [
			v := compiledMethod valueWithReceiver: receiver arguments: #()].
	] 
		on: OutOfScopeNotification 
		do: [ :ex | ex resume: true].
	FakeClassPool adopt: nil.
	
	self inform: ('Result: ', (v printStringLimitedTo: 20)).
