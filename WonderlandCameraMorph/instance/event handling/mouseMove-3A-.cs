mouseMove: evt 
	"When the user clicks in a camera window, determine which actor the    
	    user clicked on and have that actor respond to the event"
	| newEvent reactions |
	firstPersonControls == true ifTrue:[^self].
	newEvent _ self convertEvent: evt.
	mode = #stroke
		ifTrue: [self recordStroke: evt cursorPoint]
		ifFalse: [newEvent
				ifNotNil: 
					[((mode = #paint and: [newEvent getVertex ~= nil]) and: [evt commandKeyPressed not])
						ifTrue:
							[newEvent getActor = currentActor
								ifTrue: [
									self prepareAction: newEvent.
									^self perform: palette action with: newEvent]]
						ifFalse: [
							newEvent getActor hasActiveTexture
								ifTrue: [^ newEvent getActor morphicMouseMove: newEvent].
								reactions _ newEvent getActor getReactionsTo: mouseMove.
								reactions ifNotNil: [reactions do: [:aReaction | aReaction reactTo: newEvent]]]]]