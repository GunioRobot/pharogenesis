keyStroke: evt
	"Handle a keyboard event"

	| newEvent reactions |
	firstPersonControls == true "For existing camera morphs"
		ifTrue:[^self firstPersonKeystroke: evt].

	newEvent _ self convertEvent: evt.
	newEvent ifNil:[^self].
	"Check for active textures"
	newEvent getActor hasActiveTexture 
		ifTrue:[^newEvent getActor morphicKeyPress: newEvent].
	"Route to actor"
	reactions _ newEvent getActor getReactionsTo: keyPress.
	reactions ifNotNil:[ 
		reactions do: [:aReaction | aReaction reactTo: newEvent ]].
