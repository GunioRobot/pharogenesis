mouseDown: evt 
	"When the user clicks in a camera window, determine which actor the    
	         user clicked on and have that actor respond to the event"
	| newEvent reactions |
	newEvent _ self convertEvent: evt.
	newEvent
		ifNotNil: 
			[((mode = #paint and: [newEvent getVertex ~= nil]) and: [evt commandKeyPressed not])
				ifTrue:
					[self prepareAction: newEvent.
					^self perform: palette action with: newEvent]
				ifFalse:
					[newEvent getActor hasActiveTexture
						ifTrue: [^ newEvent getActor morphicMouseDown: newEvent].
					evt redButtonPressed
						ifTrue: 
							[reactions _ newEvent getActor getReactionsTo: leftMouseDown.
							mouseUpButton _ leftMouseUp]
						ifFalse: [evt yellowButtonPressed
								ifTrue: 
									[reactions _ newEvent getActor getReactionsTo: rightMouseDown.
									mouseUpButton _ rightMouseUp]
								ifFalse: [reactions _ nil]].
					reactions ifNotNil: [reactions do: [:aReaction | aReaction reactTo: newEvent]]]]