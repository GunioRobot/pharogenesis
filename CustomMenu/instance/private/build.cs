build
	"Turn myself into an invokable ActionMenu."

	| stream |
	stream _ WriteStream on: (String new).
	labels do: [: label | stream nextPutAll: label; cr].
	(labels isEmpty) ifFalse: [stream skip: -1].  "remove final cr"
	self labels: stream contents
		font: (TextStyle default fontAt: 1)
		lines: dividers.