handleEvent: evt fromMorph: sourceMorph
	"Handle the given event by using the event type to decide what to do. This method is less efficient than the specific event handling messages."
	"Note: This method cannot be used for mouse enter and leave transitions, since these events are just mouseMove events whose interpretation depends on context."

	evt isMouse ifTrue: [
		evt isMouseMove ifTrue: [
			^ self mouseStillDown: evt fromMorph: sourceMorph].
		evt isMouseDown ifTrue: [
			^ self mouseDown: evt fromMorph: sourceMorph].
		evt isMouseUp ifTrue: [
			^ self mouseUp: evt fromMorph: sourceMorph]].
	evt isKeystroke ifTrue: [
		^ self keyStroke: evt fromMorph: sourceMorph].
