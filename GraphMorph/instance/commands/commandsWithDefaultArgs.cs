commandsWithDefaultArgs
	"Return a list of (command arg1 arg2 ...) arrays where each command is followed by the default values for is parameters."

	| r |
	r _ OrderedCollection new.
	r add: #(appendValue: 1000).
	r add: #(processSamples).
	r add: #(play).
	r add: #(playOnce).
	r add: #(playBach).
	r add: #(clear).
	r add: #(reverse).
	^ r
