close
	"close if you can"
	(stream respondsTo: #close) ifTrue: [
			stream closed ifFalse: [stream close]]