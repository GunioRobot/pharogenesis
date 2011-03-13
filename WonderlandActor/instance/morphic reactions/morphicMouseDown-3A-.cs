morphicMouseDown: event
	"Handle the given event.
	If a local viewpoint is defined go to this viewpoint."
	| vp |
	(event getMorphicEvent shiftPressed and:[(vp _ self getUserPointOfView) notNil])
		ifTrue:[event getCameraMorph getCamera 
					setPointOfView: vp
					duration: 2
					asSeenBy: self.
				"Set an additional flag to avoid inbetween shift key changes"
				^self setProperty: #userTransition toValue: true].
	myTexture isMorph ifTrue:[
		self dispatchEvent: event to: myTexture.
	].