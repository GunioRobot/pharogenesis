testControl: anEvent
	"See if it is a control event for me.  
Control 1 = start recording
Control 2 = stop recording (or playing back)
Control 3 = start playing back"

	anEvent isKeystroke ifFalse: [^ self].
	anEvent controlKeyPressed ifFalse: [^ self].
	anEvent commandKeyPressed ifTrue: [^ self].	"not this"
	anEvent optionKeyPressed ifTrue: [^ self].	"not this"
	anEvent shiftPressed ifTrue: [^ self].	"not this"

	anEvent keyCharacter = $1 ifTrue: ["start recording"
		tape ifNil: [tape _ OrderedCollection new].
		state _ #record].
	anEvent keyCharacter = $2 ifTrue: ["stop recording (or playing back)"
		state _ nil].
	anEvent keyCharacter = $3 ifTrue: ["start playing back"
		state _ #play.
		tape ifNotNil: [
			tape do: [:evt | 
				anEvent hand world runStepMethods.
				anEvent hand handleEvent: evt.
				anEvent hand world displayWorld]].
		state _ nil].