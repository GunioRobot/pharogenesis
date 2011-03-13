forgetAllGrabCommandsFrom: starter
	"Forget all the commands that might be held on to in the properties dicitonary of various morphs for various reasons."

	| object |
	object := starter.
	[
		[0 == object] whileFalse: [
			object isMorph ifTrue: [object removeProperty: #undoGrabCommand].
			object := object nextObject].
		] ifError: [:err :rcvr | "object is obsolete"
			self forgetAllGrabCommandsFrom: object nextObject].

	"CommandHistory forgetAllGrabCommandsFrom: true someObject"
