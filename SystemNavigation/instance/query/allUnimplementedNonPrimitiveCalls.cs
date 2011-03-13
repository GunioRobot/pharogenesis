allUnimplementedNonPrimitiveCalls
	"Answer an Array of each message that is sent by an expression in a  
	method but is not implemented by any object in the system."
	| aStream secondStream all meth |
	all := self systemNavigation allImplementedMessages.
	aStream := (Array new: 50) writeStream.
	Cursor execute
		showWhile: [self systemNavigation
				allBehaviorsDo: [:cl | cl
						selectorsDo: [:sel | 
							secondStream := (String new: 5) writeStream.
							meth := cl compiledMethodAt: sel.
							meth primitive = 0 ifTrue: [
								meth messages
									do: [:m | (all includes: m)
											ifFalse: [secondStream nextPutAll: m;
													 space]].
								secondStream position = 0
									ifFalse: [aStream nextPut: cl name , ' ' , sel , ' calls: ' , secondStream contents]]]]].
	^ aStream contents