emitForEffect: stack on: strm
	"For #ifTrue:ifFalse: and #whileTrue: / #whileFalse: style messages, the pc is set to the jump instruction, so that mustBeBoolean exceptions can be shown correctly."
	special > 0
		ifTrue: 
			[pc _ 0.
			self perform: (MacroEmitters at: special) with: stack with: strm with: false]
		ifFalse: 
			[super emitForEffect: stack on: strm]