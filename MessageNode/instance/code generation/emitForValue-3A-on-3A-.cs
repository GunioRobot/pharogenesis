emitForValue: stack on: strm
	"For #ifTrue:ifFalse: and #whileTrue: / #whileFalse: style messages, the pc is set to the jump instruction, so that mustBeBoolean exceptions can be shown correctly."
	special > 0
		ifTrue: 
			[pc _ 0.
			self perform: (MacroEmitters at: special) with: stack with: strm with: true]
		ifFalse: 
			[receiver ~~ nil ifTrue: [receiver emitForValue: stack on: strm].
			arguments do: [:argument | argument emitForValue: stack on: strm].
			selector
				emit: stack
				args: arguments size
				on: strm
				super: receiver == NodeSuper.
			pc _ strm position]