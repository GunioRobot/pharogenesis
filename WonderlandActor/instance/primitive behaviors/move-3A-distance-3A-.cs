move: aDirection distance: aDistance 
	"Move the actor the specified distance in the specified direction, taking 1 second and using the Gently animation style."

	^ (self move: aDirection distance: aDistance duration: 1.0
			style: gently).

