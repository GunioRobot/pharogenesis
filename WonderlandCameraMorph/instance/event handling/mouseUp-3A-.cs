mouseUp: evt 
	"When the user clicks in a camera window, determine which actor the    
	user clicked on and have that actor respond to the event"
	| newEvent reactions |
	self mode = #stroke ifTrue: [self createPoohActor. ^ self mode: nil].
	newEvent _ self convertEvent: evt.
	newEvent ifNil: [^ self].
	(self mode = #paint and: [newEvent getVertex ~= nil])
		ifTrue:
			[self prepareAction: newEvent.
			^ self perform: palette action with: newEvent].
	newEvent getActor hasActiveTexture ifTrue: [^ newEvent getActor morphicMouseUp: newEvent].
	reactions _ newEvent getActor getReactionsTo: mouseUpButton.
	reactions ifNotNil: [reactions do: [:aReaction | aReaction reactTo: newEvent]]